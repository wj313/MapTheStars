// <copyright file="UserModelDto.cs" company="MapTheStars">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author>Sean Cogan</author>
// <author>Waleed Johnson</author>
// <author>Kevin Sonnen</author>
// <author>Luke Westby</author>

namespace MapTheStars.Models
{
    using System;
    using System.Data;
    using Newtonsoft.Json;

    /// <summary>
    /// Data Transfer Object for a UserModel instance. Constructor
    /// sets fields and generates Gravatar url so the full url intance
    /// does not need to be stored (just the email)
    /// </summary>
    [JsonObject]
    public class UserModelDto
    {
        /// <summary>
        /// Sets UserId, Username and Email, and converts GravatarEmail to ImageUri
        /// </summary>
        /// <param name="user">The UserModel instance to serialize</param>
        public UserModelDto(UserModel user)
        {
            this.UserId = user.UserId;
            this.Username = user.Username;
            this.Email = user.Email;
            this.ImageUri = user.GenerateGravatarUrl();
        }

        /// <summary>
        /// The id of the user in the database
        /// </summary>
        [JsonProperty("id")]
        public int UserId { get; set; }

        /// <summary>
        /// The username of the user
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The user's public-facing email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The resource location of the user's profile picture
        /// </summary>
        [JsonProperty("imageUri")]
        public string ImageUri { get; set; }
    }
}