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
    public partial class VerbalTest : ContentPage
    {
        private bool isAlive;
        private int currentLevel;
        private string answerWord;

        private List<String> seenWords;

        public VerbalTest()
        {
            seenWords = new List<String>();
            InitializeComponent();
        }

        // Events

        private void OnPlayTapped(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Button1Clicked(object sender, EventArgs e)
        {
            if (isAlive)
            {
                CheckAnswer(true);
            }
            else
            {
                StartGame();
            }
        }

        private void Button2Clicked(object sender, EventArgs e)
        {
            if (isAlive)
            {
                CheckAnswer(false);
            }
            else
            {
                Navigation.PopAsync();
            }
        }

        // Functions

        private void StartGame()
        {
            MenuLayout.IsVisible = false;
            GameLayout.IsVisible = true;
            AnswerLabel.TextDecorations = TextDecorations.None;
            seenWords.Clear();
            Button1.Text = "New";
            Button2.Text = "Seen";
            isAlive = true;
            currentLevel = 0;
            LevelLabel.Text = $"Level {currentLevel}";
        }
        private void Die()
        {
            AnswerLabel.TextDecorations = TextDecorations.Strikethrough;
            isAlive = false;
            Button1.Text = "Try Again";
            Button2.Text = "Exit";
        }

        private void NextLevel()
        {
            currentLevel++;
            LevelLabel.Text = $"Level {currentLevel}";

            answerWord = "kiisu";
            seenWords.Add(answerWord);
            AnswerLabel.Text = $"{answerWord}";
        }

        private void CheckAnswer(bool selectedNew)
        {
            if (seenWords.Contains(answerWord))
            {
                if (selectedNew)
                {
                    Die();
                }
                else
                {
                    NextLevel();
                }
            }
            else
            {
                if (selectedNew)
                {
                    NextLevel();
                }
                else
                {
                    Die();
                }
            }
            
        }
    }
}