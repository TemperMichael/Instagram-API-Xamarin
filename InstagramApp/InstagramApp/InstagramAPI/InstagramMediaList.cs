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

        public List<MediaContainer> Data { get; set; }
        public MediaMeta Meta { get; set; }
        public MediaPagination Pagination { get; set; }
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

        public MediaContainer Data { get; set; }
    }

    public class MediaCaption
    {
        public String Id { get; set; }
        public String Text { get; set; }
        public String Created_time { get; set; }
        public MediaUser From { get; }
    }

    public class MediaContainer
    {
        public String Id { get; set; }
        public MediaUser User { get; set; }
        public MediaImages Images { get; set; }
        public String Created_time { get; set; }
        public MediaCaption Caption { get; set; }
        public bool User_has_liked { get; set; }
        public MediaCounter Likes { get; set; }
        public List<String> Tags { get; set; }
        public String Filter { get; set; }
        public MediaCounter Comments { get; set; }
        public String Type { get; set; }
        public String Link { get; set; }
        public MediaLocation Location { get; set; }
        public String Attribution { get; set; }
        public List<MediaUsersInPhoto> Users_in_photo { get; set; }
    }

    public class MediaCounter
    {
        public int Count { get; set; }
    }

    public class MediaImageType
    {
        public String Width { get; set; }
        public String Height { get; set; }
        public String Url { get; set; }
    }

    public class MediaImages
    {
        public MediaImageType Thumbnail { get; set; }
        public MediaImageType Low_resolution { get; set; }
        public MediaImageType Standard_resolution { get; set; }
    }

    public class MediaLocation
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public String Created_time { get; set; }
        public String Id { get; set; }
        public String Street_address { get; set; }
        public String Name { get; set; }
    }

    public class MediaMeta
    {
        public int Code { get; set; }
    }

    public class MediaPagination { }

    public class MediaPosition
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class MediaUser
    {
        public String Id { get; set; }
        public String Full_name { get; set; }
        public String Profile_picture { get; set; }
        public String Username { get; set; }
    }

    public class MediaUsersInPhoto
    {
        public MediaUser User { get; set; }
        public MediaPosition Position { get; set; }
    }
}
