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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            Utils.mainListViews[0] = listView1;
            Utils.mainListViews[1] = listView2;

            int Size1 = listView1.Width / 2 - 12;
            columnHeader1.Width = Size1;
            columnHeader2.Width = Size1;

            int Size2 = listView2.Width / 2 - 12;
            columnHeader3.Width = Size2;
            columnHeader4.Width = Size2;

            SaveManager.Load();
            Utils.GenerateLeaderboard();
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainFormManager.MainMenu.Hide();
            GlobalVariables.isMode2 = false;
            new Form2().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.CurrentName = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainFormManager.MainMenu.Hide();
            GlobalVariables.isMode2 = true;
            new Form2().ShowDialog();
        }
    }
}
