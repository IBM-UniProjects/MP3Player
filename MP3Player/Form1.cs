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
        private WMPLib.IWMPMedia media;
        private WMPLib.IWMPPlaylist playlist;
        private ArrayList songlist;

        public MainWindow()
        {
            InitializeComponent();
            wplayer = new WMPLib.WindowsMediaPlayer(); // tworze nowy obiekt playera
            wplayer.settings.autoStart = false;
            playlist = wplayer.playlistCollection.newPlaylist("DefaultPlaylist");
            autostartCheckBox.Checked = wplayer.settings.autoStart; 
            textLabel.Text = "00:00 / 00:00";
            songlist = new ArrayList();
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
                foreach (string file in openPlaylistDialog.FileNames)
                {
                    WMPLib.IWMPMedia fileMedia = wplayer.newMedia(file);
                    playlist.appendItem(fileMedia);
                    songlist.Add(fileMedia.name + " - " + fileMedia.durationString);
                }
                wplayer.currentPlaylist = playlist;
                foreach (String song in songlist)
                {
                    Console.WriteLine(song);
                    songListBox.Items.Add(song);
                }
                updateSongTimer();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
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
            wplayer.controls.pause();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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

        private void openPlaylistDialog_FileOk(object sender, CancelEventArgs e)
        {

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
    }
}
