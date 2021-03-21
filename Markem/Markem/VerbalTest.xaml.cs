using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
            NextLevel();
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
                NextLevel();
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
        public IEnumerable<string> ReadLines(Func<Stream> streamProvider)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        private void NextLevel()

        {
            currentLevel++;
            LevelLabel.Text = $"Level {currentLevel}";

            if (random.NextDouble() < 0.25 && seenWords.Count() > 0)
            {
                int randomIndexNumber = random.Next(seenWords.Count);
                answerWord = seenWords[randomIndexNumber];
            }
            else
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                var fileStream = assembly.GetManifestResourceStream("Markem.words.txt");

                var lines = ReadLines(() => Assembly.GetExecutingAssembly().GetManifestResourceStream("Markem.words.txt")).ToList();
                int randomLineNumber = random.Next(0, lines.Count - 1);
                answerWord = lines[randomLineNumber];
            }

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
                    seenWords.Add(answerWord);
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