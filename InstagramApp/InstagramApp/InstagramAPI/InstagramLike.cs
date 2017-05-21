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

        public List<LikeUser> data { get; set; }
        public LikeMeta meta { get; set; }
    }

    public class LikeMeta
    {
        public int code { get; set; }
    }

    public class LikeUser
    {
        public String username { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String type { get; set; }
        public String id { get; set; }
    }
}
