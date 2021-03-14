using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SequenceTest : ContentPage
    {
        private Random random;

        private int currentLevel;
        private int guessCount;
        private Color answerColor;
        private Color guessColor;
        private Color whiteColor;
        private Color grayColor;

        private Button[,] board;

        private List<int[]> answerList;
        private List<int[]> guessList;

        public SequenceTest()
        {
            random = new Random();

            answerList = new List<int[]>();
            guessList = new List<int[]>();

            currentLevel = 0;

            answerColor = Color.FromHex("#FC427B");
            guessColor = Color.FromHex("#45aaf2");
            whiteColor = Color.FromHex("#ffffff");
            grayColor = Color.FromHex("#efefef");

            InitializeComponent();

            board = new Button[,] {{ Board00Button, Board01Button, Board02Button },
                                   { Board10Button, Board11Button, Board12Button },
                                   { Board20Button, Board21Button, Board22Button }};

        }

        // Events

        private void OnPlayTapped(object sender, EventArgs e)
        {
            StartGame();
            NextLevel();
        }

        private void TryAgainButtonClicked(object sender, EventArgs e)
        {
            StartGame();
            NextLevel();
        }

        private void ExitButtonClicked(object sender, EventArgs e)
        {
            Exit();
        }

        // Board Events 
        private void Board00Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(0, 0);
        }

        private void Board01Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(0, 1);
        }

        private void Board02Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(0, 2);
        }

        private void Board10Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(1, 0);
        }

        private void Board11Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(1, 1);
        }

        private void Board12Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(1, 2);
        }

        private void Board20Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(2, 0);
        }

        private void Board21Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(2, 1);
        }

        private void Board22Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(2, 2);
        }

        // Functions

        private void StartGame()
        {
            MenuLayout.IsVisible = false;
            GameOverLayout.IsVisible = false;
            GameLayout.IsVisible = true;
            currentLevel = 0;
            guessCount = 0;
            guessList.Clear();
            answerList.Clear();
        }

        private void Exit()
        {
            Navigation.PopAsync();
        }

        private async void SubmitBoardGuess(int row,  int column)
        {
            board[row, column].BackgroundColor = guessColor;
            await Task.Delay(500);
            board[row, column].BackgroundColor = whiteColor;
            guessList.Add(new int[] { row, column });
            guessCount++;
            if (string.Join(",", answerList[guessCount-1]) == string.Join(",", guessList[guessCount-1]))
            {
                if (guessCount == currentLevel)
                {
                    NextLevel();
                }
            }
            else
            {
                GameOverLayout.IsVisible = true;
                foreach (var btn in board)
                {
                    btn.IsEnabled = false;
                    btn.BackgroundColor = grayColor;
                }
            }
        }

        private async void NextLevel()
        {
            guessCount = 0;

            foreach (var btn in board)
            {
                btn.IsEnabled = false;
                btn.BackgroundColor = grayColor;
            }

            currentLevel++;
            LevelLabel.Text = $"Level {currentLevel}";

            guessList.Clear();

            int row = random.Next(0, 3);
            int column = random.Next(0, 3);
            answerList.Add(new int[] { row, column });

            await Task.Delay(1500);
            for (int i = 0; i < currentLevel; i++)
            {
                board[answerList[i][0], answerList[i][1]].BackgroundColor = answerColor;
                await Task.Delay(1000);
                board[answerList[i][0], answerList[i][1]].BackgroundColor = grayColor;
                await Task.Delay(500);
            }

            foreach (var btn in board)
            {
                btn.IsEnabled = true;
                btn.BackgroundColor = whiteColor;
            }

        }
    }
}