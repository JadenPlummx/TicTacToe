// ============================================================================
// Project Name: TicTacToe
// Description: A WPF two player Tic Tac Toe game where users
//   can enter names, track scores and even possibly
//   turn into a cat if a tie game occurs.
// Author: Jaden Plummer
// Date: October 14, 2026
// ============================================================================


using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

    // Class-level variables
        private string currentPlayer = "X";
        private int scoreX = 0;
        private int scoreO = 0;
        private int scoreCats = 0;
        private int movesCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
