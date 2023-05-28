using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackToe
{
    public partial class Form1 : Form
    {
        int ok = 1;
        int[,] grid = new int[4, 4];
        public Form1()
        {
            InitializeComponent();
        }

        int check()
        {
            if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
                return grid[0, 0];

            if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
                return grid[1, 1];

            for (int i = 0; i < 3; ++i)
            {
                if (grid[0, i] == grid[1, i] && grid[0, i] == grid[2, i])
                    return grid[0, i];

                if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                    return grid[i, 0];
            }
            return 0;
        }

        private void turn(object sender, EventArgs e)
        {
                Button b = (Button)sender;
            if (b.Text == "")
            {
                char val = b.Name[6];
                int value = val - 49;
                int x = value / 3;
                int y = value % 3;

                if (ok == 1)
                {
                    b.Text  = "X";
                    if (x >= 0 && x < 3 && y >= 0 && y < 3)
                    grid[x, y] = 1;
                }
                else
                {
                    b.Text = "0";
                    if (x >= 0 && x < 3 && y >= 0 && y < 3)
                        grid[x, y] = 2;
                }
                if (check() == 1)
                {
                    if (MessageBox.Show("X wins! Restart?", "Congratsulations!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                                grid[i, j] = 0;
                        button1.Text = "";
                        button2.Text = "";
                        button3.Text = "";
                        button4.Text = "";
                        button5.Text = "";
                        button6.Text = "";
                        button7.Text = "";
                        button8.Text = "";
                        button9.Text = "";
                        ok = 1 - ok;
                    }
                    else this.Close();
                }
                else if (check() == 2)
                {
                    if (MessageBox.Show("0 wins! Restart?", "Congratsulations!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                                grid[i, j] = 0;
                        button1.Text = "";
                        button2.Text = "";
                        button3.Text = "";
                        button4.Text = "";
                        button5.Text = "";
                        button6.Text = "";
                        button7.Text = "";
                        button8.Text = "";
                        button9.Text = "";
                        ok = 1 - ok;
                    }
                    else this.Close();
                }
                else
                {
                    bool draw = true;
                    for (int i = 0; i < 3; i++) 
                        for (int j =  0; j < 3 && draw == true; j++)
                        {
                            if (grid[i, j] == 0)
                                draw = false;
                        }
                    if (draw == true)
                    {
                        if (MessageBox.Show("Draw! Restart?", "Congratsulations!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            for (int i = 0; i < 3; i++)
                                for (int j = 0; j < 3; j++)
                                    grid[i, j] = 0;
                            button1.Text = "";
                            button2.Text = "";
                            button3.Text = "";
                            button4.Text = "";
                            button5.Text = "";
                            button6.Text = "";
                            button7.Text = "";
                            button8.Text = "";
                            button9.Text = "";
                            ok = 1 - ok;
                        }
                        else this.Close();
                    }
                }
                ok = 1 - ok;
            }
        }
    }
}
