using System;

using Xamarin.Forms;

namespace InstagramApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Button_Clicked(object sender, EventArgs e)
        {
            // Show login presenter when login button was clicked
            InstagramAuthenticator.authenticateInstagram(Navigation);
        }
    }
}
