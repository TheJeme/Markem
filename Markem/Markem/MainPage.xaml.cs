using System;

using Xamarin.Forms;

namespace Markem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ReactionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReactionTest());
        }
        private void TimeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeTest());
        }
        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NumberTest());
        }
        private void VerbalButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VerbalTest());
        }
        private void VisualButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisualTest());
        }
        private void SequenceButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SequenceTest());
        }
    }
}
