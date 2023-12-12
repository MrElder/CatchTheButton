using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchTheButton
{
    public partial class Form2 : Form
    {
        private int ElapsedSeconds = 0;
        private int TotalClick = 0;

        private bool TimerEnd = false;

        private int MaxWindowWidth;
        private int MaxWindowHeight;

        private int MaxScreenWidth;
        private int MaxScreenHeight;

        private void AfterEnd()
        {
            timer1.Stop();
            timer2.Stop();
            ElapsedSeconds = 0;
            DialogResult result = MessageBox.Show("Total: " + TotalClick.ToString(), "Game Over", MessageBoxButtons.OK);
            SaveManager.AddUpdatePlayer(GlobalVariables.isMode2 ? "mode2" : "mode1", GlobalVariables.CurrentName, TotalClick);
            SaveManager.Save();

            if (result == DialogResult.OK)
            {
                this.Close();
                Utils.GenerateLeaderboard();
                MainFormManager.MainMenu.Show();
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MaxWindowWidth = this.Size.Width;
            MaxWindowHeight = this.Size.Height;

            MaxScreenWidth = Screen.PrimaryScreen.Bounds.Width - MaxWindowWidth;
            MaxScreenHeight = Screen.PrimaryScreen.Bounds.Height - MaxWindowHeight;

            this.CenterToScreen();
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, this.Height / 2 - button1.Height / 2);
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ElapsedSeconds++;
            label1.Text = "Elapsed Time: " + ElapsedSeconds.ToString();

            if (ElapsedSeconds == GlobalVariables.MAX_DURATION)
            {
                TimerEnd = true;
                AfterEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TotalClick++;
            timer1.Stop();
            ElapsedSeconds = 0;
            label1.Text = "Elapsed Time: " + ElapsedSeconds.ToString();
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int xPos = new Random().Next(0, MaxWindowWidth - button1.Width);
            int yPos = new Random().Next(0, MaxWindowHeight - button1.Height);

            if (GlobalVariables.isMode2)
            {
                int xScreenPos = new Random().Next(0, MaxScreenWidth);
                int yScreenPos = new Random().Next(0, MaxScreenHeight);

                this.Location = new Point(xScreenPos, yScreenPos);
            }

            button1.Location = new Point(xPos, yPos);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!TimerEnd)
            {
                AfterEnd();
            }
        }
    }
}
