using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class MatchingGame : Form
    {
        // Use this Random object to choose random icons for the squares
        Random random = new Random();

        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>() { };

        // firstClicked points to the first Label control 
        // that the player clicks, but it will be null 
        // if the player hasn't clicked a label yet
        Label firstClicked;

        // secondClicked points to the second Label control 
        // that the player clicks
        Label secondClicked;

        private int sec, min, hr;
        private int miss;

        private void AssignIconsToSquares()
        {
            List<string> preIcons = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"
            };
            this.icons = preIcons;
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public MatchingGame()
        {
            InitializeComponent();
        }

        private void MatchingPuzzle_Load(object sender, EventArgs e)
        {
            AssignIconsToSquares();
            this.firstClicked = null;
            this.secondClicked = null;
            this.sec = 0;
            this.min = 0;
            this.hr = 0;
            this.miss = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                this.timer2.Start();
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the label that the player 
                // clicked, change its color to black, and return
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    this.timer3.Start();

                    return;
                }
                this.timer3.Enabled = false;
                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null,
                // so this must be the second icon the player clicked
                // Set its color to black
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Check to see if the player won
                CheckForWinner();

                // If the player clicked two matching icons, keep them 
                // black and reset firstClicked and secondClicked 
                // so the player can click another icon
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                else
                {
                    this.sec += 3;
                    this.miss++;
                    this.lblMistake.Text = String.Format("Mistake(s): " + miss.ToString());
                }

                // If the player gets this far, the player 
                // clicked two different icons, so start the 
                // timer (which will wait three quarters of 
                // a second, and then hide the icons)
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            AssignIconsToSquares();
            this.firstClicked = null;
            this.secondClicked = null;
            this.sec = 0;
            this.min = 0;
            this.hr = 0;
            this.miss = 0;
            this.lblMistake.Text = "Mistake(s): 0";
            this.lblTimer.Text = "00:00:00";
            this.timer1.Stop();
            this.timer1.Dispose();
            this.timer2.Stop();
            this.timer2.Dispose();
            this.timer3.Stop();
            this.timer3.Dispose();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer3.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
        }

        private void CheckForWinner()
        {
            // Go through all of the labels in the TableLayoutPanel, 
            // checking each one to see if its icon is matched
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            this.timer2.Stop();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}s", this.hr, this.min, this.sec);
            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            MessageBox.Show("You matched all the icons!\nTime Taken: " + elapsedTime + "\nMistake(s): " + miss.ToString(), "Congratulations");
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            if(this.sec > 59)
            {
                this.min++;
                this.sec = 0;
            }
            if(this.min > 59)
            {
                this.hr++;
                this.min = 0;
            }
            this.lblTimer.Text = String.Format("{0:00}:{1:00}:{2:00}", this.hr, this.min, this.sec);
        }
    }
}
