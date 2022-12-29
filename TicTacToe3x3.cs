using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class TicTacToe3x3 : Form
    {
        private int p1WinsCount;
        private int p2WinsCount;
        private Boolean GameEnds;
        private Boolean VsCPU;
        private Random rand = new Random();

        public TicTacToe3x3()
        {
            InitializeComponent();
            RandomizeFirstTurn();
            this.p1WinsCount = 0;
            this.p2WinsCount = 0;
            this.GameEnds = false;
            this.VsCPU = false;
        }

        public TicTacToe3x3(string mode)
        {
            InitializeComponent();
            this.p1WinsCount = 0;
            this.p2WinsCount = 0;
            this.GameEnds = false;

            if(mode == "CPU")
            {
                this.VsCPU = true;
            }
            else
            {
                this.VsCPU = false;
            }

            RandomizeFirstTurn();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.p1WinsCount = 0;
            this.p2WinsCount = 0;
            this.lblP1WCounts.Text = this.p1WinsCount.ToString();
            this.lblP2WCounts.Text = this.p2WinsCount.ToString();
            this.GameEnds = false;
            foreach (Label label in tableLayoutPanel1.Controls)
            {
                label.Text = "";
                label.BackColor = Color.White;
            }
            RandomizeFirstTurn();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.GameEnds = false;
            foreach (Label label in tableLayoutPanel1.Controls)
            {
                label.Text = "";
                label.BackColor = Color.White;
            }
            RandomizeFirstTurn();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (String.IsNullOrEmpty(label.Text))
                label.Text = this.lblSign.Text;
            else return;

            TogglePlayer();
        }

        private void RandomizeFirstTurn()
        {
            int turn = rand.Next(2);
            if (turn == 0)
            {
                this.lblTurn.Text = "Turn: Player ";
                this.lblSign.Text = "X";
            }
            else
            {
                if (this.VsCPU)
                {
                    this.lblTurn.Text = "Turn: Computer ";
                    this.lblSign.Text = "O";
                    ToggleCPU();
                }
                else
                {
                    this.lblTurn.Text = "Turn: Player ";
                    this.lblSign.Text = "O";
                }
            }
        }

        private void TogglePlayer()
        {
            CheckIfGameEnds();

            if (this.VsCPU && !this.GameEnds)
            {
                ToggleCPU();
                CheckIfGameEnds();
            }

            if (!this.GameEnds)
            {
                if (this.VsCPU)
                {
                    this.lblTurn.Text = "Turn: Player ";
                    this.lblSign.Text = "X";
                }
                else
                {
                    if (this.lblSign.Text == "X")
                        this.lblSign.Text = "O";
                    else this.lblSign.Text = "X";
                }
            }
        }

        private void ToggleCPU()
        {
            #region //Simple CPU
            //List<Label> availableLabels = new List<Label>();
            //foreach(Label label in tableLayoutPanel1.Controls)
            //{
            //    if(String.IsNullOrEmpty(label.Text))
            //        availableLabels.Add(label);
            //}

            //int randomPickLabel = rand.Next(availableLabels.Count);
            //availableLabels[randomPickLabel].Text = "O";
            //this.lblTurn.Text = "Turn: Player ";
            //this.lblSign.Text = "X";
            #endregion

            #region //Minimax Algorithm

            #endregion
        }

        private void CheckIfGameEnds()
        {
            #region //Check vertically
            if (this.label1.Text == this.lblSign.Text && this.label2.Text == this.lblSign.Text && this.label3.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label> { this.label1, this.label2, this.label3 });
                return;
            }
            if (this.label4.Text == this.lblSign.Text && this.label5.Text == this.lblSign.Text && this.label6.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label> { this.label4, this.label5, this.label6 });
                return;
            }
            if (this.label7.Text == this.lblSign.Text && this.label8.Text == this.lblSign.Text && this.label9.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label> { this.label7, this.label8, this.label9 });
                return;
            }
            #endregion

            #region //Check Horizontally
            if(this.label1.Text == this.lblSign.Text && this.label4.Text == this.lblSign.Text && this.label7.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label> { this.label1, this.label4, this.label7 });
                return;
            }
            if (this.label2.Text == this.lblSign.Text && this.label5.Text == this.lblSign.Text && this.label8.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label> { this.label2, this.label5, this.label8 });
                return;
            }
            if (this.label3.Text == this.lblSign.Text && this.label6.Text == this.lblSign.Text && this.label9.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label> { this.label3, this.label6, this.label9 });
                return;
            }
            #endregion

            #region //Check Diagonally
            //(top-left to bottom-right)
            if(this.label1.Text == this.lblSign.Text && this.label5.Text == this.lblSign.Text && this.label9.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label>() { this.label1, this.label5, this.label9 });
                return;
            }
            //(bottom-left to top-right)
            if (this.label7.Text == this.lblSign.Text && this.label5.Text == this.lblSign.Text && this.label3.Text == this.lblSign.Text)
            {
                ShowWinner(new List<Label>() { this.label7, this.label5, this.label3 });
                return;
            }
            #endregion

            foreach (Label label in tableLayoutPanel1.Controls)
            {
                if (String.IsNullOrEmpty(label.Text))
                    return;
            }
            this.GameEnds = true;
            MessageBox.Show("Game Draw!", "Game Ends");
        }

        private void ShowWinner(List<Label> winnerLabels)
        {
            this.GameEnds = true;
            if (this.lblSign.Text == "X")
                this.lblP1WCounts.Text = (++this.p1WinsCount).ToString();
            else this.lblP2WCounts.Text = (++this.p2WinsCount).ToString();
            foreach (Label label in winnerLabels)
                label.BackColor = Color.LightGreen;
            MessageBox.Show("Player " + this.lblSign.Text + " Wins!", "Game Ends");
        }

    }
}
