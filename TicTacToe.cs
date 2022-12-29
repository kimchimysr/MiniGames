using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class TicTacToe : Form
    {
        private Random rand = new Random();
        private string opponent;
        private Boolean vsCPU;
        public TicTacToe()
        {
            InitializeComponent();
        }

        public TicTacToe(string mode)
        {
            InitializeComponent();
            if (mode == "2P")
            {
                this.opponent = "Turn: Player 2's";
                this.vsCPU = false;
            }
            else
            {
                this.opponent = "Turn: Computer's";
                this.vsCPU = true;
            }
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            int randTurn = rand.Next(2);
            if(randTurn == 0)
            {
                this.lblPlayerTurn.Text = "Turn: Player 1's";
                this.lblPlayerSign.Text = "X";
            }
            else
            {
                this.lblPlayerTurn.Text = opponent;
                this.lblPlayerSign.Text = "O";
                CPUTurn();
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;

            if (String.IsNullOrEmpty(clickedLabel.Text))
            {
                clickedLabel.Text = this.lblPlayerSign.Text;
            }
            else return;

            checkForWinner();

            if (this.lblPlayerSign.Text == "O")
            {
                this.lblPlayerSign.Text = "X";
                this.lblPlayerTurn.Text = "Turn: Player 1's";
            }
            else
            {
                this.lblPlayerSign.Text = "O";
                this.lblPlayerTurn.Text = "Turn: Player 2's";
            }
            if (this.vsCPU == true)
                CPUTurn();
        }

        private void checkForWinner()
        {
            Label[,] movesList = new Label[3,3];
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                int row = 0;
                int col = 0;
                Label label = (Label)control;
                if (label.TabIndex == 1 || label.TabIndex == 2 || label.TabIndex == 3)
                    row = 0;
                else if (label.TabIndex == 4 || label.TabIndex == 5 || label.TabIndex == 6)
                    row = 1;
                else if (label.TabIndex == 7 || label.TabIndex == 8 || label.TabIndex == 9)
                    row = 2;

                if (label.TabIndex == 1 || label.TabIndex == 4 || label.TabIndex == 7)
                    col = 0;
                else if (label.TabIndex == 2 || label.TabIndex == 5 || label.TabIndex == 8)
                    col = 1;
                else if (label.TabIndex == 3 || label.TabIndex == 6 || label.TabIndex == 9)
                    col = 2;
                movesList[row, col] = label;
            }

            //if(movesList[0,0] == movesList[1,0] && movesList[1, 0] == movesList[2, 0])
            //    MessageBox.Show("Congratuation");

            List<Label> winnerLabels;
            //check horizontally
            winnerLabels = new List<Label>(3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (movesList[i, j].Text != this.lblPlayerSign.Text)
                        break;

                    winnerLabels.Add(movesList[i, j]);

                    if (j == 2)
                    {
                        showWinner(winnerLabels);
                        return;
                    }
                }
            }

            //check vertically
            winnerLabels = new List<Label>(3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (movesList[j, i].Text != this.lblPlayerSign.Text)
                        break;

                    winnerLabels.Add(movesList[j, i]);

                    if (j == 2)
                    {
                        showWinner(winnerLabels);
                        return;
                    }
                }
            }

            //check diagonally (top-left to bottom-right)
            winnerLabels = new List<Label>(3);
            for(int i = 0, j = 0; i < 3; i++, j++)
            {
                if (movesList[i, j].Text != this.lblPlayerSign.Text)
                    break;
                
                winnerLabels.Add(movesList[i,j]);

                if(j == 2)
                {
                    showWinner(winnerLabels);
                    return;
                }

            }

            //check diagonally (bottom-left to top-right)
            winnerLabels = new List<Label>(3);
            for (int i = 2, j = 0; j < 3; i--, j++)
            {
                if (movesList[i, j].Text != this.lblPlayerSign.Text)
                    break;

                winnerLabels.Add(movesList[i, j]);

                if (j == 2)
                {
                    showWinner(winnerLabels);
                    return;
                }

            }

            //check if all blocks are filled
            foreach (Label label in tableLayoutPanel1.Controls)
                if (String.IsNullOrEmpty(label.Text))
                    return;
            MessageBox.Show("Game Draw", "No Winner");
            restart();
        }

        private void showWinner(List<Label> winnerLabels)
        {
            foreach(Label label in winnerLabels)
                label.BackColor = Color.LightGreen;
            string msg;
            if (this.lblPlayerSign.Text == "X")
                msg = "Player 1 [X] Wins!";
            else msg = "Player 2 [O] Wins!";

            MessageBox.Show(msg, "Congratuation");
            restart();
        }

        private void restart()
        {
            int randTurn = rand.Next(2);
            if (randTurn == 0)
            {
                this.lblPlayerTurn.Text = "Turn: Player 1's";
                this.lblPlayerSign.Text = "X";
            }
            else
            {
                this.lblPlayerTurn.Text = opponent;
                this.lblPlayerSign.Text = "O";
                CPUTurn();
            }

            foreach(Label label in tableLayoutPanel1.Controls)
            {
                if (label.TabIndex != 0)
                {
                    label.Text = "";
                    label.BackColor = Color.White;
                }
            }
        }

        private int randNumsWithExclusion(int highestNum, HashSet<int> excl)
        {
            if (excl.Count == 0)
            {
                int index = rand.Next(highestNum);
                return index;
            }
            else
            {
                var range = Enumerable.Range(1, highestNum).Where(i => !excl.Contains(i));
                int index = rand.Next(0, highestNum - excl.Count);

                return range.ElementAt(index);
            }
        }

        private void CPUTurn()
        {
            HashSet<int> filledLabels = new HashSet<int>();
            foreach(Label label in tableLayoutPanel1.Controls)
            {
                if (!String.IsNullOrEmpty(label.Text))
                    filledLabels.Add(label.TabIndex);
            }

            int AIRandlabel = randNumsWithExclusion(9, filledLabels);

            foreach(Label label in tableLayoutPanel1.Controls)
            {
                if (label.TabIndex == AIRandlabel)
                {
                    label.Text = "O";
                    return;
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void TicTacToe_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu frm = new MainMenu();
            frm.ShowDialog();
            this.Close();
        }
    }
}
