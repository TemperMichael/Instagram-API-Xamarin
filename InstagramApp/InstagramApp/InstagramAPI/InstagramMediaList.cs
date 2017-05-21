using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace InstagramApp
{
    /// <summary>
    /// Container class for the JSON response of the Instagram API.
    /// </summary>
    public class InstagramMediaList
    {
        /// <summary>
        /// Creates an object of the container class from the given string in JSON format.
        /// </summary>
        /// <param name="jsonResponse">JSON formatted string.</param>
        /// <returns>Container object.</returns>
        public static InstagramMediaList CreateFromJsonResponse(String jsonResponse)
        {
            return JsonConvert.DeserializeObject<InstagramMediaList>(jsonResponse);
        }

        public List<MediaContainer> data { get; set; }
        public MediaMeta meta { get; set; }
        public MediaPagination pagination { get; set; }
    }

    public class InstagramMediaSingle
    {
        /// <summary>
        /// Creates an object of the container class from the given string in JSON format.
        /// </summary>
        /// <param name="jsonResponse">JSON formatted string.</param>
        /// <returns>Container object.</returns>
        public static InstagramMediaSingle CreateFromJsonResponse(String jsonResponse)
        {
            return JsonConvert.DeserializeObject<InstagramMediaSingle>(jsonResponse);
        }

        public MediaContainer data { get; set; }
    }

    public class MediaCaption
    {
        public String id { get; set; }
        public String text { get; set; }
        public String created_time { get; set; }
        public MediaUser from { get; }
    }

    public class MediaContainer
    {
        public String id { get; set; }
        public MediaUser user { get; set; }
        public MediaImages images { get; set; }
        public String created_time { get; set; }
        public MediaCaption caption { get; set; }
        public bool user_has_liked { get; set; }
        public MediaCounter likes { get; set; }
        public List<String> tags { get; set; }
        public String filter { get; set; }
        public MediaCounter comments { get; set; }
        public String type { get; set; }
        public String link { get; set; }
        public MediaLocation location { get; set; }
        public String attribution { get; set; }
        public List<MediaUsersInPhoto> users_in_photo { get; set; }
    }

    public class MediaCounter
    {
        public int count { get; set; }
    }

    public class MediaImageType
    {
        public String width { get; set; }
        public String height { get; set; }
        public String url { get; set; }
    }

    public class MediaImages
    {
        public MediaImageType thumbnail { get; set; }
        public MediaImageType low_resolution { get; set; }
        public MediaImageType standard_resolution { get; set; }
    }

    public class MediaLocation
    {
        public float longitude { get; set; }
        public float latitude { get; set; }
        public String created_time { get; set; }
        public String id { get; set; }
        public String street_address { get; set; }
        public String name { get; set; }
    }

    public class MediaMeta
    {
        public int code { get; set; }
    }

    public class MediaPagination { }

    public class MediaPosition
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class MediaUser
    {
        public String id { get; set; }
        public String full_name { get; set; }
        public String profile_picture { get; set; }
        public String username { get; set; }
    }

    public class MediaUsersInPhoto
    {
        public MediaUser user { get; set; }
        public MediaPosition position { get; set; }
    }
}
