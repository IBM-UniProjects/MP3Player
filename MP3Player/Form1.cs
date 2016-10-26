using System;
using System.Collections;
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
        private WMPLib.IWMPPlaylist playlist;
        private ArrayList songlist;
        int skinNumber;

        public MainWindow()
        {
            InitializeComponent();
            wplayer = new WMPLib.WindowsMediaPlayer(); // tworze nowy obiekt playera
            wplayer.settings.autoStart = false;
            playlist = wplayer.playlistCollection.newPlaylist("DefaultPlaylist");
            autostartCheckBox.Checked = wplayer.settings.autoStart; 
            textLabel.Text = "00:00 / 00:00";
            songlist = new ArrayList();
            SetDefaultSkin();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPlaylistDialog = new OpenFileDialog();

            openPlaylistDialog.InitialDirectory = @"c:\";
            openPlaylistDialog.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openPlaylistDialog.FilterIndex = 2;
            openPlaylistDialog.Multiselect = true;
            openPlaylistDialog.RestoreDirectory = true;

            if (openPlaylistDialog.ShowDialog() == DialogResult.OK)
            {
                songlist.Clear();
                playlist.clear();
                songListBox.Items.Clear();
                foreach (string file in openPlaylistDialog.FileNames)
                {
                    WMPLib.IWMPMedia fileMedia = wplayer.newMedia(file);
                    string songName = fileMedia.name + " - " + fileMedia.durationString;
                    playlist.appendItem(fileMedia);
                    songlist.Add(songName);
                    songListBox.Items.Add(songName);
                }
                wplayer.currentPlaylist = playlist;
                updateSongTimer();
                if (wplayer.settings.autoStart) timer1.Start();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.play();
            timer1.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wplayer.controls.stop();
            trackBar.Value = 0;
            updateSongTimer();
        }

        private void autostartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wplayer.settings.autoStart = !wplayer.settings.autoStart;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wplayer.controls.pause();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (songNameBox.Text != wplayer.currentMedia.name) {
                songNameBox.Text = wplayer.currentMedia.name;
            }

            if (wplayer.currentMedia != null && trackBar.Maximum != (int) wplayer.currentMedia.duration) {
                trackBar.Maximum = (int) Math.Ceiling(wplayer.currentMedia.duration);
            }
            if (wplayer.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                updateSongTimer();
                Console.WriteLine(wplayer.controls.currentPositionString);
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

        private void updateSongTimer()
        {
            textLabel.Text = (wplayer.controls.currentPosition > 0 ? wplayer.controls.currentPositionString : "00:00")
                + " / " + wplayer.currentMedia.durationString;
        }

        private void songListBox_DoubleClick(object sender, EventArgs e)
        {
            ListBox myListBox = (ListBox)sender;
            int songIndex = myListBox.SelectedIndex;
            wplayer.controls.playItem(playlist.Item[songIndex]);
        }

        private void SetDefaultSkin()
        {
            openFileButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\folder1.png");
            playButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\play1.png");
            pauseButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\pause1.png");
            stopButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\stop1.png");
            this.BackColor = Color.RosyBrown;
            skinNumber = 1;
        }

        private void ChangeSkin()
        {
            if (skinNumber == 1)
            {
                openFileButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\music-2.png");
                playButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\play-2.png");
                pauseButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\pause-2.png");
                stopButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\icons\stop-2.png");
                this.BackColor = Color.LightSteelBlue;
                skinNumber = 2;
            }
            else
            {
                SetDefaultSkin();
            }
        }

        private void changeSkinButton_Click(object sender, EventArgs e)
        {
            ChangeSkin();
        }
    }
}
