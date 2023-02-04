using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Core.DataSources.Devox.Models
{
    public class Metadata
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("macaddres")]
        public string Macaddres { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("shortIp")]
        public string ShortIp { get; set; }
    }

    public class GetVoxesResponse
    {
        [JsonProperty("sticky")]
        public List<Sticky> Sticky { get; set; }

        [JsonProperty("voxes")]
        public List<Vox> Voxes { get; set; }
    }

    public class Sticky
    {
        [JsonProperty("flag")]
        public bool Flag { get; set; }

        [JsonProperty("poll")]
        public List<object> Poll { get; set; }

        [JsonProperty("pollVoters")]
        public List<object> PollVoters { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("isArchived")]
        public bool IsArchived { get; set; }

        [JsonProperty("fileExtension")]
        public string FileExtension { get; set; }

        [JsonProperty("isURL")]
        public bool IsURL { get; set; }

        [JsonProperty("dice")]
        public bool Dice { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("metadata")]
        public List<Metadata> Metadata { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("sticky")]
        public bool IsSticky { get; set; }

        [JsonProperty("commentsCount")]
        public int CommentsCount { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("__v")]
        public int V { get; set; }

        [JsonProperty("blur")]
        public bool Blur { get; set; }
    }

    public class Vox
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("fileExtension")]
        public string FileExtension { get; set; }

        [JsonProperty("isURL")]
        public bool IsURL { get; set; }

        [JsonProperty("dice")]
        public bool Dice { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("flag")]
        public bool Flag { get; set; }

        [JsonProperty("commentsCount")]
        public int CommentsCount { get; set; }

        [JsonProperty("poll")]
        public List<object> Poll { get; set; }

        [JsonProperty("blur")]
        public bool Blur { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }
    }



    //public class Metadata
    //{
    //    [JsonProperty("ip")]
    //    public string Ip { get; set; }

    //    [JsonProperty("macaddres")]
    //    public string Macaddres { get; set; }

    //    [JsonProperty("location")]
    //    public string Location { get; set; }

    //    [JsonProperty("city")]
    //    public string City { get; set; }

    //    [JsonProperty("_id")]
    //    public string Id { get; set; }
    //}

    //public class GetVoxesResponse
    //{
    //    [JsonProperty("sticky")]
    //    public List<Sticky> Sticky { get; set; }

    //    [JsonProperty("voxes")]
    //    public List<Vox> Voxes { get; set; }
    //}

    //public class Sticky
    //{
    //    [JsonProperty("flag")]
    //    public bool Flag { get; set; }

    //    [JsonProperty("poll")]
    //    public List<bool> Poll { get; set; }

    //    [JsonProperty("pollVoters")]
    //    public List<bool> PollVoters { get; set; }

    //    [JsonProperty("_id")]
    //    public string Id { get; set; }

    //    [JsonProperty("title")]
    //    public string Title { get; set; }

    //    [JsonProperty("description")]
    //    public string Description { get; set; }

    //    [JsonProperty("category")]
    //    public int Category { get; set; }

    //    [JsonProperty("filename")]
    //    public string Filename { get; set; }

    //    [JsonProperty("isArchived")]
    //    public bool IsArchived { get; set; }

    //    [JsonProperty("fileExtension")]
    //    public string FileExtension { get; set; }

    //    [JsonProperty("isURL")]
    //    public bool IsURL { get; set; }

    //    [JsonProperty("dice")]
    //    public bool Dice { get; set; }

    //    [JsonProperty("username")]
    //    public string Username { get; set; }

    //    [JsonProperty("metadata")]
    //    public List<Metadata> Metadata { get; set; }

    //    [JsonProperty("url")]
    //    public string Url { get; set; }

    //    [JsonProperty("sticky")]
    //    public bool IsSticky { get; set; }

    //    [JsonProperty("commentsCount")]
    //    public int CommentsCount { get; set; }

    //    [JsonProperty("date")]
    //    public DateTime Date { get; set; }

    //    [JsonProperty("lastUpdate")]
    //    public DateTime LastUpdate { get; set; }

    //    [JsonProperty("__v")]
    //    public int V { get; set; }

    //    [JsonProperty("blur")]
    //    public bool Blur { get; set; }
    //}

    //public class Vox
    //{
    //    [JsonProperty("_id")]
    //    public string Id { get; set; }

    //    [JsonProperty("title")]
    //    public string Title { get; set; }

    //    [JsonProperty("category")]
    //    public int Category { get; set; }

    //    [JsonProperty("filename")]
    //    public string Filename { get; set; }

    //    [JsonProperty("fileExtension")]
    //    public string FileExtension { get; set; }

    //    [JsonProperty("isURL")]
    //    public bool IsURL { get; set; }

    //    [JsonProperty("dice")]
    //    public bool Dice { get; set; }

    //    [JsonProperty("url")]
    //    public string Url { get; set; }

    //    [JsonProperty("flag")]
    //    public bool Flag { get; set; }

    //    [JsonProperty("commentsCount")]
    //    public int CommentsCount { get; set; }

    //    [JsonProperty("poll")]
    //    public List<object> Poll { get; set; }

    //    [JsonProperty("blur")]
    //    public bool Blur { get; set; }

    //    [JsonProperty("date")]
    //    public DateTime Date { get; set; }

    //    [JsonProperty("lastUpdate")]
    //    public DateTime LastUpdate { get; set; }
    //}


}
