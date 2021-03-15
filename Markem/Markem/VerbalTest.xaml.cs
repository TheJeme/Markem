using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerbalTest : ContentPage
    {
        private Random random;

        private bool isAlive;
        private int currentLevel;
        private string answerWord;

        private List<String> seenWords;

        public VerbalTest()
        {
            random = new Random();
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
            currentLevel = 1;
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

            if (random.NextDouble() < 0.3 && seenWords.Count() > 0)
            {
                int randomIndexNumber = random.Next(seenWords.Count);
                answerWord = seenWords[randomIndexNumber];
            }
            else
            {
                var lines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "words.txt"));
                int randomLineNumber = random.Next(0, lines.Length - 1);
                answerWord = lines[randomLineNumber];
            }

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