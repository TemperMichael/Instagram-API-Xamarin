using System;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramApp
{
    /// <summary>
    /// A class which shows example calls of the Instagram API methods and how you can handle and access the results of them.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSuccessPage : ContentPage
    {
        StackLayout layout = new StackLayout { Padding = new Thickness(5, 10) };
        String fontColor = "#000000";
        int fontSize = 16;

        public LoginSuccessPage()
        {
            InitializeComponent();

            this.Content = layout;

            var jsonResponse = "";

            // Shows an example how you get information of the current user
            Task getUserSelf = new Task(() =>
            {
                jsonResponse = InstagramAPI.GetUserSelf().Result;
                InstagramUser userSelf = InstagramUser.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("UserSelf JSON response: " + jsonResponse);

                var id = new Label { Text = "Id: " + userSelf.Data.Id, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(id);

                var username = new Label { Text = "Username: " + userSelf.Data.Username, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(username);

                var webImage = new Image();
                webImage.Source = ImageSource.FromUri(new Uri(userSelf.Data.Profile_picture));
                layout.Children.Add(webImage);

                var bio = new Label { Text = "Bio: " + userSelf.Data.Bio, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(bio);

                var website = new Label { Text = "Website: " + userSelf.Data.Website, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(website);

                var amountOfPics = new Label { Text = "Amount of pics: " + userSelf.Data.Counts.Media, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(amountOfPics);

                var amountOfFollows = new Label { Text = "Amount of follows: " + userSelf.Data.Counts.Follows, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(amountOfFollows);

                var amountOfFollower = new Label { Text = "Amount of follower: " + userSelf.Data.Counts.Followed_by, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(amountOfFollower);

                var meta = new Label { Text = "Meta: " + userSelf.Meta.Code, TextColor = Color.FromHex(fontColor), FontSize = fontSize };
                layout.Children.Add(meta);
            });
            getUserSelf.Start();
            getUserSelf.Wait();

            // Shows an example how you get information of the an other user
            Task getUserOther = new Task(() =>
            {
                jsonResponse = InstagramAPI.GetUserOther("2142923999").Result;
                InstagramUser userOther = InstagramUser.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("UserOther username: " + userOther.Data.Username);
            });
            getUserOther.Start();
            getUserOther.Wait();

            // Shows an example how you get all the recent media of the current user
            Task getAllMediaSelf = new Task(() =>
            {
                jsonResponse = InstagramAPI.GetUserMediaSelf().Result;
                InstagramMediaList mediaSelf = InstagramMediaList.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("AllMediaSelf filter: " + mediaSelf.Data[0].Filter);
            });
            getAllMediaSelf.Start();
            getAllMediaSelf.Wait();

            // Shows an example how you get all the recent media of an other user
            Task getAllMediaOther = new Task(() =>
            {
                jsonResponse = InstagramAPI.GetUserMediaOther("2142923999").Result;
                InstagramMediaList mediaOther = InstagramMediaList.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("AllMediaOther likes: " + mediaOther.Data[0].Likes.Count);
            });
            getAllMediaOther.Start();
            getAllMediaOther.Wait();

            // Shows an example how you get more information of a media
            Task getSingleMediaInfo = new Task(() =>
            {
                jsonResponse = InstagramAPI.GetMediaInfo("1065424377547227936_2142923999").Result;
                InstagramMediaSingle mediaSingle = InstagramMediaSingle.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("SingleMediaInfo id: " + mediaSingle.Data.Id);
            });
            getSingleMediaInfo.Start();
            getSingleMediaInfo.Wait();

            // Shows an example how you set a like on a media
            Task addLike = new Task(() =>
            {
                jsonResponse = InstagramAPI.SetLike("1065424377547227936_2142923999").Result;
                InstagramLike media = InstagramLike.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("AddLike response code: " + media.Meta.Code);
            });
            addLike.Start();
            addLike.Wait();

            // Shows an example how you get all likes on a media
            Task getLikes = new Task(() =>
            {
                jsonResponse = InstagramAPI.GetLikes("1065424377547227936_2142923999").Result;
                InstagramLike media = InstagramLike.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("GetLikes username: " + media.Data[0].Username);
            });
            getLikes.Start();
            getLikes.Wait();

            // Shows an example how you remove a like on a media
            Task removeLike = new Task(() =>
            {
                jsonResponse = InstagramAPI.RemoveLike("1065991007700419021_2142923999").Result;
                InstagramLike media = InstagramLike.CreateFromJsonResponse(jsonResponse);
                Debug.WriteLine("RemoveLike response code: " + media.Meta.Code);
            });
            removeLike.Start();
            removeLike.Wait();
        }
    }
}