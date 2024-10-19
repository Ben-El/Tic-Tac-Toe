using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int TurnCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void אודותהמשחקToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(".המשחק נוצר על-ידי בן-אל", "אודות המשחק");
        }

        private void יציאהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            TurnCounter++;
            CheckWinner();
        }
        private void CheckWinner()
        {
            bool IsWinner = false;

            //בדיקות בכיוון האופקי
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && !A1.Enabled)
                IsWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && !B1.Enabled)
                IsWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && !C1.Enabled)
                IsWinner = true;

            //בדיקות בכיוון האנכי
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && !A1.Enabled)
                IsWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && !A2.Enabled)
                IsWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && !A3.Enabled)
                IsWinner = true;

            //בדיקות באלכסונים
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && !A1.Enabled)
                IsWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && !C1.Enabled)
                IsWinner = true;

            if (IsWinner == true)
            {
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " Wins!!!", "congratulations!!!");
                DisableButtons();
            }
            else
            {
                if (TurnCounter == 9)
                    MessageBox.Show("It's a draw!!!", "woo hoo!!!");
            }
        }
        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void משחקחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            TurnCounter = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }




        }
    }
}

