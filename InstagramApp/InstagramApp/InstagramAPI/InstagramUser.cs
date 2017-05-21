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

        public UserData data { get; set; }
        public UserMeta meta { get; set; }
    }

    public class UserCounts
    {
        public int media { get; set; }
        public int follows { get; set; }
        public int followed_by { get; set; }
    }

    public class UserData
    {
        public string id { get; set; }
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string full_name { get; set; }
        public string bio { get; set; }
        public string website { get; set; }
        public UserCounts counts { get; set; }
    }

    public class UserMeta
    {
        public int code { get; set; }
    }
}
