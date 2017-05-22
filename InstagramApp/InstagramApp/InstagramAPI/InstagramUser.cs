using Newtonsoft.Json;

using System;

namespace InstagramApp
{
    /// <summary>
    /// Container class for the JSON response of the Instagram API.
    /// </summary>
    public class InstagramUser
    {
        /// <summary>
        /// Creates an object of the container class from the given string in JSON format.
        /// </summary>
        /// <param name="jsonResponse">JSON formatted string.</param>
        /// <returns>Container object.</returns>
        public static InstagramUser CreateFromJsonResponse(String jsonResponse)
        {
            return JsonConvert.DeserializeObject<InstagramUser>(jsonResponse);
        }

        public UserData Data { get; set; }
        public UserMeta Meta { get; set; }
    }

    public class UserCounts
    {
        public int Media { get; set; }
        public int Follows { get; set; }
        public int Followed_by { get; set; }
    }

    public class UserData
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Profile_picture { get; set; }
        public string Full_name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public UserCounts Counts { get; set; }
    }

    public class UserMeta
    {
        public int Code { get; set; }
    }
}
