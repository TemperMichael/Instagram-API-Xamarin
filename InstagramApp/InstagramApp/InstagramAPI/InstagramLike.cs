using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace InstagramApp
{
    /// <summary>
    /// Container class for the JSON response of the Instagram API.
    /// </summary>
    public class InstagramLike
    {
        /// <summary>
        /// Creates an object of the container class from the given string in JSON format.
        /// </summary>
        /// <param name="jsonResponse">JSON formatted string.</param>
        /// <returns>Container object.</returns>
        public static InstagramLike CreateFromJsonResponse(String jsonResponse)
        {
            return JsonConvert.DeserializeObject<InstagramLike>(jsonResponse);
        }

        public List<LikeUser> Data { get; set; }
        public LikeMeta Meta { get; set; }
    }

    public class LikeMeta
    {
        public int Code { get; set; }
    }

    public class LikeUser
    {
        public String Username { get; set; }
        public String First_name { get; set; }
        public String Last_name { get; set; }
        public String Type { get; set; }
        public String Id { get; set; }
    }
}
