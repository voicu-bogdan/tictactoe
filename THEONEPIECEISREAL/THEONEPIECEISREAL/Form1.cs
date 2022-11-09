using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THEONEPIECEISREAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            newGame();
            checkWin();
        }
        Button[,] casuta = new Button[4, 4];
        void newGame()
        {
            for(int i = 1; i<=3; i++)
            {
                for(int j = 1; j <=3; j++)
                {
                    casuta[i, j] = new Button();
                    casuta[i, j].Width = 100;
                    casuta[i, j].Height = 100;
                    casuta[i, j].Location = new Point((i - 1) * 100, (j - 1) * 100);
                    casuta[i, j].Name = "casuta" + i + j;
                    casuta[i, j].Font = new Font("Arial", 20f);
                    //casuta[i, j].Text = " " + i + j;
                    panel1.Controls.Add(casuta[i,j]);
                    casuta[i, j].Click += new EventHandler(casuta_click);
                }
            }
        }
        void checkWin()
        {
            for(int i = 1; i<=3; i++)
            {
                if (casuta[i, 1].Text != "" && casuta[i, 1].Text == casuta[i, 2].Text && casuta[i,2].Text == casuta[i, 3].Text)
                {
                    timer1.Enabled = false;
                    DialogResult dr;
                    dr = MessageBox.Show(casuta[i, 1].Text + " wins", "Exit", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                        this.Close();
                }
                if (casuta[1, i].Text != "" && casuta[1, i].Text == casuta[2, i].Text && casuta[2, i].Text == casuta[3, i].Text)
                {
                    timer1.Enabled = false;
                    DialogResult dr;
                    dr = MessageBox.Show(casuta [1, i].Text + " wins", "Exit", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                        this.Close();
                }
                if (casuta[1, 1].Text != "" && casuta[1, 1].Text == casuta[2, 2].Text && casuta[2, 2].Text == casuta[3, 3].Text)
                {
                    timer1.Enabled = false;
                    DialogResult dr;
                    dr = MessageBox.Show(casuta[1, 1].Text + " wins", "Exit", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                        this.Close();
                }
                if (casuta[1, 3].Text != "" && casuta[1, 3].Text == casuta[2, 2].Text && casuta[2, 2].Text == casuta[3, 1].Text)
                {
                    timer1.Enabled = false;
                    DialogResult dr;
                    dr = MessageBox.Show(casuta[1, 3].Text + " wins", "Exit", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                        this.Close();
                }
                if(casuta[1, 1].Text != "" && casuta[1, 2].Text != "" && casuta[1, 3].Text != "" && casuta[2, 1].Text != "" && casuta[2, 2].Text != "" && casuta[2, 3].Text != "" && casuta[3, 1].Text != "" && casuta[3, 2].Text != "" && casuta[3, 3].Text != "")
                {
                    timer1.Enabled = false;
                    DialogResult dr;
                    dr = MessageBox.Show("Draw!", "Exit", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                        this.Close();
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int cnt = 0;
        private void casuta_click(object sender, EventArgs e)
        {
            Button apasat = (Button)sender;
            int x = Convert.ToInt16(apasat.Name.Substring(6, 1));
            int y = Convert.ToInt16(apasat.Name.Substring(7, 1));
            if (casuta[x, y].Text == "")
            {
                cnt = cnt + 1;
                if (cnt % 2 == 1) casuta[x, y].Text = "X";
                else casuta[x, y].Text = "O";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            casuta[1, 1].Text = "";
            casuta[1, 2].Text = "";
            casuta[1, 3].Text = "";
            casuta[2, 1].Text = "";
            casuta[2, 2].Text = "";
            casuta[2, 3].Text = "";
            casuta[3, 1].Text = "";
            casuta[3, 2].Text = "";
            casuta[3, 3].Text = "";
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkWin();
        }
    }
}
