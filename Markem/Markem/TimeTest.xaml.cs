using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTest : ContentPage
    {
        private Random random;

        private DateTime timeNow;

        private int targetTime;
        private bool isAlive;

        public TimeTest()
        {
            random = new Random();

            isAlive = false;

            InitializeComponent();
        }

        // Events

        private void OnScreenTapped(object sender, EventArgs e)
        {


            if (MenuLayout.IsVisible)
            {
                MenuLayout.IsVisible = false;
                GameLayout.IsVisible = true;

                StartTimer();
            }
            else if (GameLayout.IsVisible)
            {
                if (isAlive)
                {
                    isAlive = false;
                    TryAgainLabel.Text = "Tap to try again";
                    double milliSeconds = (float)(DateTime.Now - timeNow).TotalMilliseconds;
                    milliSeconds = Math.Round(milliSeconds / 1000, 1);
                    if (!milliSeconds.ToString().Contains(','))
                    {
                        CountLabel.Text = $"{milliSeconds},0";
                    }
                    else
                    {
                        CountLabel.Text = $"{milliSeconds}";
                    }                    
                }
                else if (TryAgainLabel.Text == "Tap to try again")
                {
                    StartTimer();
                }
            }
        }

        // Functions

        private void StartTimer()
        {
            targetTime = random.Next(12, 45);
            TargetTimeLabel.Text = $"{targetTime}.0";
            timeNow = DateTime.Now;
            Device.StartTimer(TimeSpan.FromMilliseconds(1), OnTimedEvent);
            TryAgainLabel.Text = "";
        }

        private bool OnTimedEvent()
        {
            double milliSeconds = (float)(DateTime.Now - timeNow).TotalMilliseconds;
            milliSeconds = Math.Round(milliSeconds / 1000, 1);
            if (!milliSeconds.ToString().Contains(','))
            {
                CountLabel.Text = $"{milliSeconds},0";
            }
            else
            {
                CountLabel.Text = $"{milliSeconds}";
            }
            if (milliSeconds > 6)
            {
                isAlive = true;
                CountLabel.Text = "";
                return false;
            }
            return true;
        }
    }
}