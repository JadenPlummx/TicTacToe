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

        /// <summary>
        /// Checks if three buttons contain matching values and highlights them if matching.
        /// </summary>
        private bool CheckLine(Button btn1, Button btn2, Button btn3)
        {
            // Local variables declared at top of scope block
            string content1;
            string content2;
            string content3;
            Brush winColor;

            content1 = btn1.Content?.ToString();
            content2 = btn2.Content?.ToString();
            content3 = btn3.Content?.ToString();

            if (!string.IsNullOrEmpty(content1) && content1 == content2 && content1 == content3)
            {
                // Highlight winning line with a bright color to show the winning line
                winColor = Brushes.LightGreen;
                btn1.Background = winColor;
                btn2.Background = winColor;
                btn3.Background = winColor;
                return true;
            }

            return false;
        }

        /// <summary>
        /// checks there is a winner or a cat's game.
        /// </summary>
        private void CheckForWin()
        {
            // Local variable declared at top of scope block
            bool hasWon;

            hasWon = false;

            // Check Rows
            if (CheckLine(buttonTopLeft, buttonTopCenter, buttonTopRight) ||
                CheckLine(buttonMiddleLeft, buttonMiddleCenter, buttonMiddleRight) ||
                CheckLine(buttonBottomLeft, buttonBottomCenter, buttonBottomRight))
            {
                hasWon = true;
            }
            // Check Columns
            else if (CheckLine(buttonTopLeft, buttonMiddleLeft, buttonBottomLeft) ||
                     CheckLine(buttonTopCenter, buttonMiddleCenter, buttonBottomCenter) ||
                     CheckLine(buttonTopRight, buttonMiddleRight, buttonBottomRight))
            {
                hasWon = true;
            }
            // Check Diagonals
            else if (CheckLine(buttonTopLeft, buttonMiddleCenter, buttonBottomRight) ||
                     CheckLine(buttonTopRight, buttonMiddleCenter, buttonBottomLeft))
            {
                hasWon = true;
            }

            if (hasWon)
            {
                // Display winner message box and update score
                MessageBox.Show($"{currentPlayer} is the Winner!", "Winner Announcement", MessageBoxButton.OK, MessageBoxImage.Information);

                if (currentPlayer == "X")
                {
                    scoreX++;
                    scoreXLabel.Content = scoreX.ToString();
                }
                else
                {
                    scoreO++;
                    scoreOLabel.Content = scoreO.ToString();
                }

                ResetBoard();
            }
            else if (movesCount == 9)
            {
                // Cat's game / tie handling
                MessageBox.Show("It's a Cat's Game (Tie)!", "Tie Announcement", MessageBoxButton.OK, MessageBoxImage.Information);
                scoreCats++;
                scoreCatsLabel.Content = scoreCats.ToString();
                ResetBoard();
            }
        }

        /// <summary>
        /// Handles click events on any of the 9 game board buttons.
        /// </summary>
        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            // Local variable declared at top of scope block
            Button clickedButton;

            clickedButton = sender as Button;

            if (clickedButton != null && string.IsNullOrEmpty(clickedButton.Content?.ToString()))
            {
                // Set content to current player, disable button, and increment moves
                clickedButton.Content = currentPlayer;
                clickedButton.IsEnabled = false;
                movesCount++;

                // Check if this move resulted in a win or tie
                CheckForWin();

                // If game hasn't reset yet, switch player turn
                if (clickedButton.IsEnabled == false && movesCount < 9)
                {
                    if (currentPlayer == "X")
                    {
                        currentPlayer = "O";
                    }
                    else
                    {
                        currentPlayer = "X";
                    }

                    currentPlayerLabel.Content = currentPlayer;
                }
            }
        }

        /// <summary>
        /// Allows users to choose or switch the starting player before moves are made.
        /// </summary>
        private void choosePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (movesCount == 0)
            {
                if (currentPlayer == "X")
                {
                    currentPlayer = "O";
                }
                else
                {
                    currentPlayer = "X";
                }
                currentPlayerLabel.Content = currentPlayer;
            }
            else
            {
                MessageBox.Show("Cannot change starting player once the game has started!", "Notice", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Clears board buttons, allows players to click them,
        /// </summary>
        private void ResetBoard()
        {
            buttonTopLeft.Content = string.Empty;
            buttonTopLeft.IsEnabled = true;
            buttonTopLeft.ClearValue(Button.BackgroundProperty);

            buttonTopCenter.Content = string.Empty;
            buttonTopCenter.IsEnabled = true;
            buttonTopCenter.ClearValue(Button.BackgroundProperty);

            buttonTopRight.Content = string.Empty;
            buttonTopRight.IsEnabled = true;
            buttonTopRight.ClearValue(Button.BackgroundProperty);

            buttonMiddleLeft.Content = string.Empty;
            buttonMiddleLeft.IsEnabled = true;
            buttonMiddleLeft.ClearValue(Button.BackgroundProperty);

            buttonMiddleCenter.Content = string.Empty;
            buttonMiddleCenter.IsEnabled = true;
            buttonMiddleCenter.ClearValue(Button.BackgroundProperty);

            buttonMiddleRight.Content = string.Empty;
            buttonMiddleRight.IsEnabled = true;
            buttonMiddleRight.ClearValue(Button.BackgroundProperty);

            buttonBottomLeft.Content = string.Empty;
            buttonBottomLeft.IsEnabled = true;
            buttonBottomLeft.ClearValue(Button.BackgroundProperty);

            buttonBottomCenter.Content = string.Empty;
            buttonBottomCenter.IsEnabled = true;
            buttonBottomCenter.ClearValue(Button.BackgroundProperty);

            buttonBottomRight.Content = string.Empty;
            buttonBottomRight.IsEnabled = true;
            buttonBottomRight.ClearValue(Button.BackgroundProperty);

            currentPlayer = "X";
            currentPlayerLabel.Content = currentPlayer;
            movesCount = 0;
        }

        /// <summary>
        /// Resets the game board and all scores to zero.
        /// </summary>
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetBoard();
            scoreX = 0;
            scoreO = 0;
            scoreCats = 0;
            scoreXLabel.Content = "0";
            scoreOLabel.Content = "0";
            scoreCatsLabel.Content = "0";
        }

        /// <summary>
        /// Disintegrate the application.
        /// </summary>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
