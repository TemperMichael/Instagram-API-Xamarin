using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Auth;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace InstagramApp.Droid
{
    public class OAuthLoginPresenter
    {
        public void Login(Authenticator authenticator)
        {
            Xamarin.Forms.Forms.Context.StartActivity(authenticator.GetUI(Xamarin.Forms.Forms.Context));
        }
    }
}