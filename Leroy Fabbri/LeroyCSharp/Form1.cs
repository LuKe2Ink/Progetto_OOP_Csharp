using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LeroyCSharp
{
    public partial class Form1 : Form
    {
        private bool active = true;
        readonly SoundPlayer audio = new SoundPlayer(Properties.Resources.BeneaththeMask);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playaudio();
        }

        private void playaudio()
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.BeneaththeMask);
            audio.Play();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Ancora in lavorazione";
            string title = "ReDungeonGame";
            _ = MessageBox.Show(message, title);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (active == true)
            {
                audio.Stop();
                active = false;
            }
            else
            {
                audio.Play();
                active = true;
            }
        }
    }
}
