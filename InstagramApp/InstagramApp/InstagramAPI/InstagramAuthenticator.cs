using System;

using Xamarin.Auth;
using Xamarin.Forms;

namespace InstagramApp
{
    class InstagramAuthenticator
    {

    /// <summary> To use this method you need to register the login presenter. Look in the documentation of this method (Right mouse click -> Go to definition)
    /// or visit: https://developer.xamarin.com/guides/xamarin-forms/cloud-services/authentication/oauth/  </summary>
    /// You need to create a OAuthLoginPresenter class in the iOS and Android App and register the presenter after the "global::Xamarin.Forms.Forms.Init();" line
    /// in the AppDelegate of the iOS App and in the MainActivity of the Android App.
    /// --------------------------------------------------------------------------------------------------
    /// iOS OAuthLoginPresenter Class:
    ///  namespace InstagramApp.iOS
    ///  {
    ///    public class OAuthLoginPresenter
    ///        {
    ///           UIViewController rootViewController;
    ///
    ///            public void Login(Authenticator authenticator)
    ///            {
    ///                authenticator.Completed += AuthenticatorCompleted;
    ///
    ///
    ///                rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
    ///                rootViewController.PresentViewController((UINavigationController)authenticator.GetUI(), true, null);
    ///            }
    ///
    ///            void AuthenticatorCompleted(object sender, AuthenticatorCompletedEventArgs e)
    ///            {
    ///                rootViewController.DismissViewController(true, null);
    ///                ((Authenticator)sender).Completed -= AuthenticatorCompleted;
    ///            }
    ///        }
    ///    }
    /// --------------------------------------------------------------------------------------------------
    /// iOS AppDelegate:
    ///   namespace InstagramApp.iOS
    ///   {
    ///    [Register("AppDelegate")]
    ///        public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    ///        {
    ///            public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    ///            {
    ///                global::Xamarin.Forms.Forms.Init();
    ///
    ///                Xamarin.Auth.Presenters.OAuthLoginPresenter.PlatformLogin = (authenticator) =>
    ///                {
    ///                    var oAuthLogin = new OAuthLoginPresenter();
    ///                    oAuthLogin.Login(authenticator);
    ///                 };
    ///                LoadApplication(new App());
    ///
    ///                return base.FinishedLaunching(app, options);
    ///            }
    ///        }
    ///    }
    /// --------------------------------------------------------------------------------------------------
    /// Android OAuthLoginPresenter Class:
    ///   namespace InstagramApp.Droid
    ///   {
    ///    public class OAuthLoginPresenter
    ///        {
    ///            public void Login(Authenticator authenticator)
    ///           {
    ///                Xamarin.Forms.Forms.Context.StartActivity(authenticator.GetUI(Xamarin.Forms.Forms.Context));
    ///            }
    ///        }
    ///    }
    /// --------------------------------------------------------------------------------------------------
    /// Android Manifest:
    ///   namespace InstagramApp.Droid
    ///   {
    ///       [Activity(Label = "InstagramApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    ///       public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    ///       {
    ///           protected override void OnCreate(Bundle bundle)
    ///           {
    ///               TabLayoutResource = Resource.Layout.Tabbar;
    ///               ToolbarResource = Resource.Layout.Toolbar;
    ///   
    ///               base.OnCreate(bundle);
    ///   
    ///               global::Xamarin.Forms.Forms.Init(this, bundle);
    ///   
    ///               Xamarin.Auth.Presenters.OAuthLoginPresenter.PlatformLogin = (authenticator) =>
    ///               {
    ///                   var oAuthLogin = new OAuthLoginPresenter();
    ///                   oAuthLogin.Login(authenticator);
    ///               };
    ///   
    ///               LoadApplication(new App());
    ///           }
    ///       }
    ///   }
    /// --------------------------------------------------------------------------------------------------
    /// <param name="navigation"> The standard navigation element of Xamarin. (INavigation VisualElement.Navigation; just type "Navigation" in a ContentPage) </param>
    public static void authenticateInstagram(INavigation navigation)
        {
           var auth = new OAuth2Authenticator(
           Constants.ClientId,
           Constants.Scopes,
           new Uri(Constants.AuthorizationUrl),
           new Uri(Constants.RedirectUri));

           var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
           presenter.Completed += (sending, eventArgs) =>
           {
                if (eventArgs.IsAuthenticated)
                {
                    Application.Current.Properties["Account"] = eventArgs.Account;
                    navigation.PushAsync(new LoginSuccessPage());
                }
                else
                {
                    // Login canceled
                }
            };
            presenter.Login(auth);
        }
    }
}
