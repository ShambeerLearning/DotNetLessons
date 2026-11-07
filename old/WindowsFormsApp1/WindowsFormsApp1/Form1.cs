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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Spam> list = new List<Spam>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt64(sperma_v_rot.Text); i++)
            {
                Spam daun = new Spam();
                daun.FormClosed += (suckingcock, args) => list.Remove(daun);
                list.Add(daun);
                daun.Show();
            }

            if (Convert.ToInt64(sperma_v_rot.Text) >= 10)
            {
                string soundPath = @".\sound.wav";
                if (System.IO.File.Exists(soundPath))
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play(); // Асинхронное воспроизведение
                }
                else
                {
                    MessageBox.Show("Файл не найден!");
                }
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            sperma_v_rot.Text = Convert.ToString(Convert.ToInt64(sperma_v_rot.Text) + 1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void sperma_v_rot_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var FormsToClose = new List<Spam>(list);
            foreach (var spam in FormsToClose)
            {
                spam.Close();
            }
            list.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sperma_v_rot.Text = "0";
        }
    }
}
