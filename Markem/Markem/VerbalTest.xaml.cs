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
        public VerbalTest()
        {
            InitializeComponent();
        }

        private void OnPlayTapped(object sender, EventArgs e)
        {

        }
    }
}