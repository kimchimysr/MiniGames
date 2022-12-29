using System;
using System.Windows.Forms;

namespace MiniGames
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn3x32P_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicTacToe3x3 frm = new TicTacToe3x3("2P");
            frm.ShowDialog();
            this.Close();
        }

        private void btn3x3CPU_Click(object sender, EventArgs e)
        {
            this.Hide();
            MatchingGame game = new MatchingGame();
            game.ShowDialog();
            this.Close();
        }
    }
}
