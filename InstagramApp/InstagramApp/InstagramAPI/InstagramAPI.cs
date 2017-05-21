using System;
using System.Threading.Tasks;

using Xamarin.Auth;
using Xamarin.Forms;

namespace InstagramApp
{
    /// <summary>
    /// A class to access some endpoints of the Instagram API. Note that I don't use all of the endpoints here.
    /// For more endpoints look at the Instagram API documentation. (https://www.instagram.com/developer/endpoints/)
    /// </summary>
    class InstagramAPI 
    {
        /// <summary>
        /// Get a list of users who have liked this media.
        /// The public_content scope is required for media that does not belong to the owner of the access_token.
        /// </summary>
        /// <param name="mediaId">The id of the media of which you want to have the likes.</param>
        /// <returns>Returns the list in JSON format.</returns>
        public static Task<string> GetLikes(string mediaId)
        {
            return makeRequest("GET", String.Format("https://api.instagram.com/v1/media/{0}/likes", mediaId));
        }

        /// <summary>
        /// Get information about a media object. Use the type field to differentiate between image and video media in the response.
        /// You will also receive the user_has_liked field which tells you whether the owner of the access_token has liked this media.
        /// Note that I don't handle videos in this example project. The InstagramMediaList has only a images member in the MediaContainer.
        /// </summary>
        /// <param name="mediaId">The id of the media of which you want to have more info.</param>
        /// <returns>Returns the info in JSON format.</returns>
        public static Task<string> GetMediaInfo(string mediaId)
        {
            return makeRequest("GET", String.Format("https://api.instagram.com/v1/media/{0}", mediaId));
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// The public_content scope is required if the user is not the owner of the access_token.
        /// Note that I don't use all parameters here. 
        /// For more parameters look at the Instagram API documentation. (https://www.instagram.com/developer/endpoints/users/)
        /// </summary>
        /// <param name="userId">The id of the user of which you want to have the media.</param>
        /// <returns>Returns the media of the other user in JSON format.</returns>
        public static Task<string> GetUserMediaOther(string userId)
        {
            return makeRequest("GET", String.Format("https://api.instagram.com/v1/users/{0}/media/recent/", userId));
        }

        /// <summary>
        /// Get the most recent media published by the owner of the access_token.
        /// Note that I don't use all parameters here. 
        /// For more parameters look at the Instagram API documentation. (https://www.instagram.com/developer/endpoints/users/)
        /// </summary>
        /// <returns>Returns the media of the user in JSON format.</returns>
        public static Task<string> GetUserMediaSelf()
        {
            return makeRequest("GET", "https://api.instagram.com/v1/users/self/media/recent/");
        }

        /// <summary>
        /// Get information about a user.
        /// The public_content scope is required if the user is not the owner of the access_token.
        /// </summary>
        /// <param name="userId">The id of the user of which you want to have the information.</param>
        /// <returns>Returns the information of the other user in JSON format.</returns>
        public static Task<string> GetUserOther(string userId)
        {
            return makeRequest("GET", String.Format("https://api.instagram.com/v1/users/{0}/", userId));
        }

        /// <summary>
        /// Get information about the owner of the access_token.
        /// </summary>
        /// <returns>>Returns the information of the user in JSON format.</returns>
        public static Task<string> GetUserSelf()
        {
            return makeRequest("GET", "https://api.instagram.com/v1/users/self/");
        }

        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// The public_content scope is required for media that does not belong to the owner of the access_token.
        /// </summary>
        /// <param name="mediaId">The id of the media of which you want to remove the like.</param>
        /// <returns>Returns a informational code.</returns>
        public static Task<string> RemoveLike(string mediaId)
        {
            return makeRequest("DELETE", String.Format("https://api.instagram.com/v1/media/{0}/likes", mediaId));
        }

        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// The public_content scope is required for media that does not belong to the owner of the access_token.
        /// </summary>
        /// <param name="mediaId">The id of the media of which you want to set the like.</param>
        /// <returns>Returns a informational code.</returns>
        public static Task<String> SetLike(string mediaId)
        {
            return makeRequest("POST", String.Format("https://api.instagram.com/v1/media/{0}/likes", mediaId));
        }

        /// <summary>
        /// Helper method to make a async request.
        /// </summary>
        /// <param name="command">Specifies the type of request. (DELETE/GET/POST)</param>
        /// <param name="url">The URL to the endpoint of the Instagram API.</param>
        /// <returns>The result of the request as string.</returns>
        async static Task<String> makeRequest(String command, String url)
        {
            var request = new OAuth2Request(command, new Uri(url), null, (Account)Application.Current.Properties["Account"]);
            var response = await request.GetResponseAsync();
            if (response != null)
            {
                return response.GetResponseText();
            }
            return "[ERROR] Request";
        }
    }
}
