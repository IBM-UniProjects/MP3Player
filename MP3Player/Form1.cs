using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class MainWindow : Form
    {
        private WMPLib.WindowsMediaPlayer wplayer;
        private WMPLib.IWMPMedia media;
        private WMPLib.IWMPPlaylist playlist;

        public MainWindow()
        {
            InitializeComponent();
            wplayer = new WMPLib.WindowsMediaPlayer(); // tworze nowy obiekt playera
            wplayer.settings.autoStart = false;
            playlist = wplayer.playlistCollection.newPlaylist("DefaultPlaylist");
            autostartCheckBox.Checked = wplayer.settings.autoStart; 
            textLabel.Text = "*stop*";
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            String filePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                media = wplayer.newMedia(filePath);
                wplayer.URL = media.sourceURL;
                trackBar.Maximum = (int) media.duration;
                songNameBox.Text = media.name;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.stop();
        }

        private void autostartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wplayer.settings.autoStart = !wplayer.settings.autoStart;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.pause();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wplayer.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                textLabel.Text = wplayer.controls.currentPositionString;
                trackBar.Value = (int) wplayer.controls.currentPosition;
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            timer1.Stop();
            wplayer.controls.currentPosition = trackBar.Value;
            System.Threading.Thread.Sleep(300);
            timer1.Start();
        }

        private void openPlaylistDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPlaylistDialog = new OpenFileDialog();

            openPlaylistDialog.InitialDirectory = "c:\\";
            openPlaylistDialog.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openPlaylistDialog.FilterIndex = 2;
            openPlaylistDialog.Multiselect = true;
            openPlaylistDialog.RestoreDirectory = true;

            if (openPlaylistDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openPlaylistDialog.FileNames)
                {
                    playlist.appendItem(wplayer.newMedia(file));
                }
                wplayer.currentPlaylist = playlist;
            }
        }
    }
}
