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
        private WMPLib.WindowsMediaPlayer wplayer; // przenioslem inicjacje do konstruktora

        public MainWindow() // to jest konstruktor
        {
            InitializeComponent();
            this.wplayer = new WMPLib.WindowsMediaPlayer(); // tworze nowy obiekt playera
            wplayer.settings.autoStart = false;
            autostartCheckBox.Checked = wplayer.settings.autoStart; // przypisalem zaznaczenie checkboxa do wartosci autostartu - jak zmienisz autostart to zobaczymy to w checkboxie
            // to jest o tyle fajne, że pole "Checked" dostaje referencję do tego samego obiektu co "autoStart" więc zmiany na obu polach to zmiany w tym samym obiekcie
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            String filePath = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                Console.WriteLine(filePath);

                wplayer.URL = filePath;
                
           
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.pause();
        }

        private void autostartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wplayer.settings.autoStart = !wplayer.settings.autoStart; // zamieniam na autostart na wartosc przeciwna
        }
    }
}
