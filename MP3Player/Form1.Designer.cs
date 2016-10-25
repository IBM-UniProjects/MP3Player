namespace MP3Player
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.openFileButton = new System.Windows.Forms.Button();
            this.imgButtons = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.autostartCheckBox = new System.Windows.Forms.CheckBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.songNameBox = new System.Windows.Forms.TextBox();
            this.openPlaylistDialog = new System.Windows.Forms.OpenFileDialog();
            this.songListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.ImageIndex = 7;
            this.openFileButton.ImageList = this.imgButtons;
            this.openFileButton.Location = new System.Drawing.Point(129, 131);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(50, 50);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // imgButtons
            // 
            this.imgButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgButtons.ImageStream")));
            this.imgButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgButtons.Images.SetKeyName(0, "play-button.png");
            this.imgButtons.Images.SetKeyName(1, "stop.png");
            this.imgButtons.Images.SetKeyName(2, "pause-symbol.png");
            this.imgButtons.Images.SetKeyName(3, "volume-down.png");
            this.imgButtons.Images.SetKeyName(4, "volume-off.png");
            this.imgButtons.Images.SetKeyName(5, "volume-up.png");
            this.imgButtons.Images.SetKeyName(6, "sound-mute.png");
            this.imgButtons.Images.SetKeyName(7, "folder-1.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // playButton
            // 
            this.playButton.ImageIndex = 0;
            this.playButton.ImageList = this.imgButtons;
            this.playButton.Location = new System.Drawing.Point(185, 131);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(50, 50);
            this.playButton.TabIndex = 1;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.ImageIndex = 1;
            this.stopButton.ImageList = this.imgButtons;
            this.stopButton.Location = new System.Drawing.Point(297, 131);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(50, 50);
            this.stopButton.TabIndex = 2;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(78, 80);
            this.trackBar.Maximum = 1000;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(400, 45);
            this.trackBar.TabIndex = 4;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // autostartCheckBox
            // 
            this.autostartCheckBox.AutoSize = true;
            this.autostartCheckBox.Location = new System.Drawing.Point(129, 187);
            this.autostartCheckBox.Name = "autostartCheckBox";
            this.autostartCheckBox.Size = new System.Drawing.Size(67, 17);
            this.autostartCheckBox.TabIndex = 5;
            this.autostartCheckBox.Text = "autostart";
            this.autostartCheckBox.UseVisualStyleBackColor = true;
            this.autostartCheckBox.CheckedChanged += new System.EventHandler(this.autostartCheckBox_CheckedChanged);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(75, 38);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(35, 13);
            this.textLabel.TabIndex = 6;
            this.textLabel.Text = "label1";
            // 
            // pauseButton
            // 
            this.pauseButton.ImageIndex = 2;
            this.pauseButton.ImageList = this.imgButtons;
            this.pauseButton.Location = new System.Drawing.Point(241, 131);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(50, 50);
            this.pauseButton.TabIndex = 7;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // songNameBox
            // 
            this.songNameBox.Enabled = false;
            this.songNameBox.Location = new System.Drawing.Point(78, 54);
            this.songNameBox.Name = "songNameBox";
            this.songNameBox.Size = new System.Drawing.Size(400, 20);
            this.songNameBox.TabIndex = 8;
            // 
            // openPlaylistDialog
            // 
            this.openPlaylistDialog.FileName = "openPlaylistDialog";
            this.openPlaylistDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openPlaylistDialog_FileOk);
            // 
            // songListBox
            // 
            this.songListBox.FormattingEnabled = true;
            this.songListBox.Location = new System.Drawing.Point(103, 210);
            this.songListBox.Name = "songListBox";
            this.songListBox.Size = new System.Drawing.Size(357, 95);
            this.songListBox.TabIndex = 11;
            this.songListBox.DoubleClick += new System.EventHandler(this.songListBox_DoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 373);
            this.Controls.Add(this.songListBox);
            this.Controls.Add(this.songNameBox);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.autostartCheckBox);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.openFileButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.CheckBox autostartCheckBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imgButtons;
        private System.Windows.Forms.TextBox songNameBox;
        private System.Windows.Forms.OpenFileDialog openPlaylistDialog;
        private System.Windows.Forms.ListBox songListBox;
    }
}

