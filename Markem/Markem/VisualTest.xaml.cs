using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualTest : ContentPage
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

        public VisualTest()
        {
            random = new Random();

            answerList = new List<int[]>();
            guessList = new List<int[]>();

            answerColor = Color.FromHex("#FC427B");
            guessColor = Color.FromHex("#f7b731");
            whiteColor = Color.FromHex("#ffffff");
            grayColor = Color.FromHex("#efefef");

            InitializeComponent();

            board = new Button[,] {{ Board00Button, Board01Button, Board02Button, Board03Button, Board04Button, Board05Button },
                                   { Board10Button, Board11Button, Board12Button, Board13Button, Board14Button, Board15Button },
                                   { Board20Button, Board21Button, Board22Button, Board23Button, Board24Button, Board25Button },
                                   { Board30Button, Board31Button, Board32Button, Board33Button, Board34Button, Board35Button },
                                   { Board40Button, Board41Button, Board42Button, Board43Button, Board44Button, Board45Button },
                                   { Board50Button, Board51Button, Board52Button, Board53Button, Board54Button, Board55Button }};
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

        private void Board03Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(0, 3);
        }

        private void Board04Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(0, 4);
        }

        private void Board05Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(0, 5);
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

        private void Board13Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(1, 3);
        }

        private void Board14Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(1, 4);
        }

        private void Board15Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(1, 5);
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

        private void Board23Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(2, 3);
        }

        private void Board24Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(2, 4);
        }

        private void Board25Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(2, 5);
        }

        private void Board30Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(3, 0);
        }

        private void Board31Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(3, 1);
        }

        private void Board32Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(3, 2);
        }

        private void Board33Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(3, 3);
        }

        private void Board34Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(3, 4);
        }

        private void Board35Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(3, 5);
        }

        private void Board40Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(4, 0);
        }
        private void Board41Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(4, 1);
        }

        private void Board42Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(4, 2);
        }

        private void Board43Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(4, 3);
        }

        private void Board44Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(4, 4);
        }

        private void Board45Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(4, 5);
        }

        private void Board50Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(5, 0);
        }
        private void Board51Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(5, 1);
        }

        private void Board52Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(5, 2);
        }

        private void Board53Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(5, 3);
        }

        private void Board54Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(5, 4);
        }

        private void Board55Button_Clicked(object sender, EventArgs e)
        {
            SubmitBoardGuess(5, 5);
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
            answerList.Clear();

            await Task.Delay(1000);

            int answerCount;
            if (currentLevel < 15)
            {
                answerCount = currentLevel;
            }
            else
            {
                answerCount = 15;
            }

            for (int i = 0; i < answerCount; i++)
            {
                int row = random.Next(0, 6);
                int column = random.Next(0, 6);

                if (answerList.Count > 0)
                {
                    for (int j = 0; j < answerList.Count; j++)
                    {
                        if (string.Join(",", answerList[j]) == $"{row},{column}")
                        {
                            row = random.Next(0, 6);
                            column = random.Next(0, 6);
                            j = 0;
                        }
                    }
                }

                answerList.Add(new int[] { row, column });

                board[row, column].BackgroundColor = answerColor;
            }

            await Task.Delay(1000);

            foreach (var btn in board)
            {
                btn.IsEnabled = true;
                btn.BackgroundColor = whiteColor;
            }

        }


        private async void SubmitBoardGuess(int row, int column)
        {
            if (guessCount >= currentLevel)
            {
                return;
            }

            guessList.Add(new int[] { row, column });

            bool isRightAnswer = false;

            for (int i = 0; i < currentLevel; i++)
            {
                if (string.Join(",", answerList[i]) == string.Join(",", guessList[guessCount]))
                {
                    isRightAnswer = true;
                    break;
                }
            }

            if (isRightAnswer)
            {
                guessCount++;
                board[row, column].BackgroundColor = guessColor;
                if (guessCount == currentLevel)
                {
                    await Task.Delay(500);
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
    }
}