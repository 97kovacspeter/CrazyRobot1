namespace Robot
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( GameForm ) );
            this.menuStrip1 = new System.Windows.Forms.MenuStrip( );
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.continueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.x11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.x15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.timer1 = new System.Windows.Forms.Timer( this.components );
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog( );
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog( );
            this.label1 = new System.Windows.Forms.Label( );
            this.menuStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.pauseToolStripMenuItem,
            this.continueToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.newGameToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 584, 24 );
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size( 50, 20 );
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler( this.pauseToolStripMenuItem_Click );
            // 
            // continueToolStripMenuItem
            // 
            this.continueToolStripMenuItem.Enabled = false;
            this.continueToolStripMenuItem.Name = "continueToolStripMenuItem";
            this.continueToolStripMenuItem.Size = new System.Drawing.Size( 68, 20 );
            this.continueToolStripMenuItem.Text = "Continue";
            this.continueToolStripMenuItem.Click += new System.EventHandler( this.continueToolStripMenuItem_Click_1 );
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Enabled = false;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size( 45, 20 );
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler( this.loadToolStripMenuItem_Click_1 );
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size( 43, 20 );
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler( this.saveToolStripMenuItem_Click_1 );
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.x7ToolStripMenuItem,
            this.x11ToolStripMenuItem,
            this.x15ToolStripMenuItem} );
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size( 77, 20 );
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler( this.newGameToolStripMenuItem_Click_1 );
            // 
            // x7ToolStripMenuItem
            // 
            this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            this.x7ToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
            this.x7ToolStripMenuItem.Text = "7x7";
            this.x7ToolStripMenuItem.Click += new System.EventHandler( this.x7ToolStripMenuItem_Click );
            // 
            // x11ToolStripMenuItem
            // 
            this.x11ToolStripMenuItem.Name = "x11ToolStripMenuItem";
            this.x11ToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
            this.x11ToolStripMenuItem.Text = "11x11";
            this.x11ToolStripMenuItem.Click += new System.EventHandler( this.x11ToolStripMenuItem_Click );
            // 
            // x15ToolStripMenuItem
            // 
            this.x15ToolStripMenuItem.Name = "x15ToolStripMenuItem";
            this.x15ToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
            this.x15ToolStripMenuItem.Text = "15x15";
            this.x15ToolStripMenuItem.Click += new System.EventHandler( this.x15ToolStripMenuItem_Click );
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler( this.timer1_Tick );
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Robot table (*.rtl)|*.rtl";
            this.openFileDialog1.Title = "Loading Robot table";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Robot table (*.rtl)|*.rtl";
            this.saveFileDialog1.Title = "Saving Robot table";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 290, 5 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 35, 13 );
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 584, 561 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.menuStrip1 );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "Crazy Robot";
            this.Load += new System.EventHandler( this.GameForm_Load );
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x15ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

