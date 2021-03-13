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
        public NumberTest()
        {
            InitializeComponent();
        }

        private void OnPlayTapped(object sender, EventArgs e)
        {
            StartGame();
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            SubmitGuess();
        }

        private void StartGame()
        {
            MenuLayout.IsVisible = false;
            GameLayout.IsVisible = true;
        }

        private void SubmitGuess()
        {
            AnswerLayout.
        }
    }
}