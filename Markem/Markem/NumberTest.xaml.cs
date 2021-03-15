using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumberTest : ContentPage
    {

        private int currentLevel;
        private string answer;
        private string guess;
        
        private Random random;

        public NumberTest()
        {
            random = new Random();
            currentLevel = 0;

            InitializeComponent();
        }

        // Events

        private void OnPlayTapped(object sender, EventArgs e)
        {
            StartGame();
            NextLevel();
            StartTimer();
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (GuessEntry.Text.ToString().Length > 0)
            {
                CheckAnswer();
                ShowResultLayout();
            }
        }

        private void ContinueButtonClicked(object sender, EventArgs e)
        {
            ShowAnswerLayout();
            NextLevel();
            StartTimer();
        }

        private void TryAgainButtonClicked(object sender, EventArgs e)
        {
            StartGame();
            ShowAnswerLayout();
            NextLevel();
            StartTimer();
        }

        private void ExitButtonClicked(object sender, EventArgs e)
        {
            Exit();
        }

        private void TimerProgressBarChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (TimerProgressBar.Progress == 1)
            {
                ShowGuessLayout();
            }
        }

        // Functions

        private void StartGame()
        {
            MenuLayout.IsVisible = false;
            GameLayout.IsVisible = true;
            currentLevel = 0;
        }

        private void NextLevel()
        {
            currentLevel++;
            LevelLabel.Text = $"Level {currentLevel}";
            answer = "";

            for (int i = 0; i < currentLevel; i++)
            {
                answer += random.Next(0, 9).ToString();
            }
            AnswerLabel.Text = answer;
        }


        private void CheckAnswer()
        {
            guess = GuessEntry.Text;
            if (guess.Equals(answer))
            {
                AliveLayout.IsVisible = true;
                GameOverLayout.IsVisible = false;
                YourAnswerLabel.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                AliveLayout.IsVisible = false;
                GameOverLayout.IsVisible = true;
                YourAnswerLabel.TextDecorations = TextDecorations.Strikethrough;
            }
            GuessEntry.Text = "";
        }

        private void Exit()
        {
            Navigation.PopAsync();
        }

        private void ShowAnswerLayout()
        {
            GuessLayout.IsVisible = false;
            ResultLayout.IsVisible = false;
            AnswerLayout.IsVisible = true;
        }

        private void ShowGuessLayout()
        {
            ResultLayout.IsVisible = false;
            AnswerLayout.IsVisible = false;
            GuessLayout.IsVisible = true;
        }

        private void ShowResultLayout()
        {
            GuessLayout.IsVisible = false;
            AnswerLayout.IsVisible = false;
            ResultLayout.IsVisible = true;

            RealAnswerLabel.Text = answer;
            YourAnswerLabel.Text = guess;
        }

        private async void StartTimer()
        {
            TimerProgressBar.Progress = 0;
            await TimerProgressBar.ProgressTo(1, 5000+Convert.ToUInt32(currentLevel*100), Easing.Linear);
        }
    }
}