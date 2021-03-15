using System;
using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReactionTest : ContentPage
    {
        private Random random;

        private Color waitColor;
        private Color resultColor;
        private Color readyColor;

        private DateTime timeNow;
        private DateTime timeTapped;

        public ReactionTest()
        {
            random = new Random();

            waitColor = Color.FromHex("#eb4d4b");
            resultColor = Color.FromHex("#45aaf2");
            readyColor = Color.FromHex("#4cd137");

            InitializeComponent();
        }

        // Events

        private void OnScreenTapped(object sender, EventArgs e)
        {

            if (MenuLayout.IsVisible)
            {
                MenuLayout.IsVisible = false;
                ResultLayout.IsVisible = false;
                ReadyLayout.IsVisible = false;
                GameLayout.IsVisible = true;
                WaitLayout.IsVisible = true;

                int waitTime = random.Next(1500, 5000);
                Device.StartTimer(TimeSpan.FromMilliseconds(waitTime), OnTimedEvent);
            }
            else if (WaitLayout.IsVisible)
            {
                WaitLayout.IsVisible = false;
                ResultLayout.IsVisible = true;

                ReactionPage.BackgroundColor = resultColor;
                TimeLabel.Text = "Too soon";
            }
            else if (ReadyLayout.IsVisible)
            {
                ReadyLayout.IsVisible = false;
                ResultLayout.IsVisible = true;
                timeTapped = DateTime.Now;
                TimeSpan timeSpan = timeTapped - timeNow;
                ReactionPage.BackgroundColor = resultColor;
                TimeLabel.Text = $"{(int)timeSpan.TotalMilliseconds} ms";
            }
            else if (ResultLayout.IsVisible)
            {

                ResultLayout.IsVisible = false;
                WaitLayout.IsVisible = true;

                ReactionPage.BackgroundColor = waitColor;
                int waitTime = random.Next(1500, 5000);
                Device.StartTimer(TimeSpan.FromMilliseconds(waitTime), OnTimedEvent);
            }
        }

        // Functions

        private bool OnTimedEvent()
        {
            if (WaitLayout.IsVisible)
            {
                WaitLayout.IsVisible = false;
                ReadyLayout.IsVisible = true;
                ReactionPage.BackgroundColor = readyColor;
                timeNow = DateTime.Now;
            }

            return false;
        }
    }
}