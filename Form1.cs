using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool isX = true;
        bool gameOver = false;
        bool tie = false;
        int timesClicked = 0;
        string won = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            a.Text = "Score for x is:0";
            b.Text = "Score for o is:0";

            foreach (Button btn in panel1.Controls.OfType<Button>())
            {
                btn.Click += buttonClicked;
            }
        }
        private void buttonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text != "") return;
            btn.Text = isX ? "x" : "o";
            timesClicked++;

            Button[] buttons = panel1.Controls.OfType<Button>().ToArray();

            for (int i = buttons.Length; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (buttons[0].Text != "" && buttons[0].Text == buttons[1].Text && buttons[0].Text == buttons[2].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                    if (buttons[0].Text != "" && buttons[0].Text == buttons[4].Text && buttons[0].Text == buttons[8].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                    if (buttons[0].Text != "" && buttons[0].Text == buttons[3].Text && buttons[0].Text == buttons[6].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                }
                if (i == 4)
                {
                    if (buttons[4].Text != "" && buttons[4].Text == buttons[1].Text && buttons[4].Text == buttons[7].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                    if (buttons[4].Text != "" && buttons[4].Text == buttons[3].Text && buttons[4].Text == buttons[5].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                    if (buttons[4].Text != "" && buttons[4].Text == buttons[2].Text && buttons[4].Text == buttons[6].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                }
                if (i == 8)
                {
                    if (buttons[2].Text != "" && buttons[8].Text == buttons[5].Text && buttons[8].Text == buttons[2].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                    if (buttons[8].Text != "" && buttons[8].Text == buttons[7].Text && buttons[8].Text == buttons[6].Text)
                    {
                        won = buttons[i].Text;
                        gameOver = true;
                    }
                }
            }
            if(timesClicked  == 9 && !gameOver)
            {
                tie = true;

            }
            if (gameOver ||  tie)
            {
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                if (gameOver)
                {
                    if (isX)
                    {

                        a.Text = "Score for x is:" + (int.Parse(a.Text.Substring(15)) + 1).ToString();
                    }
                    else
                    {
                        b.Text = "Score for o is:" + (int.Parse(b.Text.Substring(15)) + 1).ToString();
                    }
                    MessageBox.Show(won +  " Won!");
                }
                else
                {
                    MessageBox.Show("Tied!");
                }
                isX = true;
                gameOver = false;
                tie = false;
                timesClicked = 0;
            }
            else isX = !isX;
        }
    }
}
