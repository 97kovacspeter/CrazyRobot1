using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot.Model;
using Robot.Persistence;


namespace Robot
{
    public partial class GameForm : Form
    {
        #region Fields

        private IDataAccess _dataAccess;
        private GameModel _model;
        private Button[ , ] _gameButtons;
        private Timer _timer;
        private int _size = 9;

        #endregion

        #region Constructors

        public GameForm()
        {
            InitializeComponent( );
        }

        private void GameForm_Load( object sender, EventArgs e )
        {
            _dataAccess = new FileDataAccess( );
            _model = new GameModel( _dataAccess );
            GenerateTable( _size );

            // időzítő létrehozása
            _timer = new Timer
            {
                Interval = 100
            };
            label1.Text = "TIMER: 0";
            _timer.Tick += new EventHandler( timer1_Tick );

            ViewUpdate( this, null );
            _model.GameAdvanced += new EventHandler( ViewUpdate );
            _model.GameOver += new EventHandler( GameOver );
            _timer.Start( );
        }

        #endregion

        #region Timer

        private void timer1_Tick( object sender, EventArgs e )
        {
            _model.AdvanceTime( ); // játék léptetése
        }

        #endregion

        #region Table generating

        /// <summary>
        /// Tábla generálás
        /// </summary>
        private void GenerateTable( int size )
        {
            if (_gameButtons != null)
            {
                for (int i = 0; i < _gameButtons.GetLength( 0 ); ++i)
                {
                    for (int j = 0; j < _gameButtons.GetLength( 1 ); ++j)
                    {
                        Controls.Remove( _gameButtons[ i, j ] );
                    }
                }
            }
            _gameButtons = new Button[ size, size ];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    _gameButtons[ i, j ] = new Button
                    {
                        Location = new Point( 5 + 40 * j, 20 + 40 * i ),
                        Size = new Size( 40, 40 ),
                        TabIndex = 100 + i * 10 + j
                    };
                    _gameButtons[ i, j ].MouseClick += new MouseEventHandler( ButtonGrid_MouseClick );

                    Controls.Add( _gameButtons[ i, j ] );
                }
            }
        }

        #endregion

        #region Update

        public void ViewUpdate( object sender, EventArgs e )
        {
            label1.Text = "TIMER: " + (_model.GameTime / 10).ToString( ) + ":" + (_model.GameTime % 10).ToString( );
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {

                    if (_model.Table.FieldValues[ i, j ] == FieldType.PermaWall)
                    {
                        _gameButtons[ i, j ].BackgroundImage = (Image)(Properties.Resources.perma);
                    }
                    else if (_model.Table.FieldValues[ i, j ] == FieldType.Wall)
                    {
                        _gameButtons[ i, j ].BackgroundImage = (Image)(Properties.Resources.wall);
                    }
                    else if (_model.Table.FieldValues[ i, j ] == FieldType.Ruined)
                    {
                        _gameButtons[ i, j ].BackgroundImage = (Image)(Properties.Resources.ruined);
                    }
                    else if (_model.Table.FieldValues[ i, j ] == FieldType.Magnet)
                    {
                        _gameButtons[ i, j ].BackgroundImage = (Image)(Properties.Resources.magnet);
                    }
                    else if (_model.Table.FieldValues[ i, j ] == FieldType.Empty)
                    {
                        _gameButtons[ i, j ].BackColor = Color.White;
                        _gameButtons[ i, j ].BackgroundImage = null;
                    }

                }
            }

            _gameButtons[ _model.PlayerXValue, _model.PlayerYValue ].BackgroundImage = Properties.Resources.robot;

        }

        #endregion

        #region GameOver

        public void GameOver( object sender, EventArgs e )
        {

            if (MessageBox.Show( "You won! Your time is: " + _model.GameTime / 10 + ":" + _model.GameTime % 10 + " Want to start new game?", "You won!", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                _model.NewGame( _size );
            }
            else
            {
                _model.Pause( );
            }


        }

        #endregion

        #region Grid event handlers

        /// <summary>
        /// Gombrács eseménykezelője.
        /// </summary>
        private void ButtonGrid_MouseClick( Object sender, MouseEventArgs e )
        {
            // a TabIndex-ből megkapjuk a sort és oszlopot
            int x = ((sender as Button).TabIndex - 100) / 10;
            int y = ((sender as Button).TabIndex - 100) % 10;

            FieldType value = _model.Table.FieldValues[ x, y ];

            bool check = CheckWall( value );

            if (x == _model.PlayerXValue && y == _model.PlayerYValue)
            {
                check = false;
            }
            if (check)
            {
                _model.Table.FieldValues[ x, y ] = FieldType.Wall;
            }
            ViewUpdate( this, null );
        }

        private bool CheckWall( FieldType value )
        {
            switch (value)
            {
                case FieldType.Empty:
                    return true;
                default:
                    return false;
            }
        }

        #endregion

        #region Menu events


        private void x7ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            _size = 9;
            _model.NewGame( _size );
            GenerateTable( _size );
        }

        private void x11ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            _size = 13;
            _model.NewGame( _size );
            GenerateTable( _size );
        }

        private void x15ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            _size = 17;
            _model.NewGame( _size );
            GenerateTable( _size );
        }

        private void pauseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            _timer.Stop( );
            _model.Pause( );

            pauseToolStripMenuItem.Enabled = false;
            continueToolStripMenuItem.Enabled = true;
            loadToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        private void continueToolStripMenuItem_Click_1( object sender, EventArgs e )
        {
            _timer.Start( );
            _model.Continue( );
            pauseToolStripMenuItem.Enabled = true;
            continueToolStripMenuItem.Enabled = false;
            loadToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        private async void loadToolStripMenuItem_Click_1( object sender, EventArgs e )
        {
            _timer.Stop( );

            if (openFileDialog1.ShowDialog( ) == DialogResult.OK)
            {
                try
                {
                    await _model.LoadGameAsync( openFileDialog1.FileName );
                }
                catch (Exception)
                {
                    MessageBox.Show( "Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    _model.NewGame( _size );
                }
            }

            _size = _model.ModelSize;
            _model.Pause( );
            GenerateTable( _size );
            ViewUpdate( this, null );
        }

        private async void saveToolStripMenuItem_Click_1( object sender, EventArgs e )
        {
            _timer.Stop( );

            if (saveFileDialog1.ShowDialog( ) == DialogResult.OK)
            {
                try
                {

                    await _model.SaveGameAsync( saveFileDialog1.FileName );
                }
                catch (Exception)
                {
                    MessageBox.Show( "Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            _model.Pause( );
        }

        private void newGameToolStripMenuItem_Click_1( object sender, EventArgs e )
        {

        }

        #endregion
    }
}
