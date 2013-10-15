// <copyright file="UserModelExtensions.cs" company="MapTheStars">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author>Sean Cogan</author>
// <author>Waleed Johnson</author>
// <author>Kevin Sonnen</author>
// <author>Luke Westby</author>

namespace MapTheStars.Models
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using MapTheStars.Models;

    /// <summary>
    /// Implements various static extension methods to call from an instance
    /// of the UserModel class
    /// </summary>
    public static class UserModelExtensions
    {
        /// <summary>
        /// Base url for Gravatar image requests
        /// </summary>
        private const string gravatarBaseUrl = "http://www.gravatar.com/avatar/";

        /// <summary>
        /// Image file extension for use in Gravatar image requests
        /// </summary>
        private const string gravatarExtension = ".jpg";

        /// <summary>
        /// Returns a fully formed default Gravatar request url based on the
        /// user's GravatarEmail field. If the field is null, "" is used and
        /// it is up to the client to set a default param in the query string
        /// </summary>
        /// <param name="user">The calling instance of UserModel</param>
        /// <returns>The full generated Gravatar url</returns>
        public static string GenerateGravatarUrl(this UserModel user)
        {
            // work on user's GravatarEmail or the empty string if not set
            var emailString = user.GravatarEmail ?? string.Empty;
            
            // clean and lower working string
            var cleanedString = emailString.Trim().ToLowerInvariant();

            // hash the cleaned string
            var md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(cleanedString));

            // build a lowercase hex string from the hash value
            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            var completedHash = sBuilder.ToString();

            // piece the final result together
            var generatedUrl = gravatarBaseUrl + completedHash + gravatarExtension;
            return generatedUrl;
        }
    }
}