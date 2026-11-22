using System;
using System.Drawing;
using System.Windows.Forms;

namespace task13
{
    public partial class Form1 : Form
    {
        int speedX = 5;
        int speedY = 5;

        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 20;
            }
            if (e.KeyCode == Keys.Right && panel1.Right < ClientSize.Width)
            {
                panel1.Left += 20;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += speedX;
            pictureBox1.Top += speedY;

            
            if (pictureBox1.Left <= 0 || pictureBox1.Right >= ClientSize.Width)
            {
                speedX = -speedX;
            }

          
            if (pictureBox1.Top <= 0)
            {
                speedY = -speedY;
            }

         
            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds) && speedY > 0)
            {
                speedY = -speedY;
                score++;
                Text = "Xal: " + score;
            }

         
            if (pictureBox1.Top > panel1.Bottom)
            {
                timer1.Stop();

                MessageBox.Show(
                    "Oyun bitdi. Yekun xal: " + score + ". Yeni oyun üçün OK düyməsinə bas.",
                    "Oyun Bitdi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                score = 0;
                Text = "Xal: 0";

                pictureBox1.Location = new Point(100, 50);
                speedX = 5;
                speedY = 5;

                timer1.Start();
            }
        }
    }
}
