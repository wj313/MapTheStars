// <copyright file="UserModel.cs" company="MapTheStars">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author>Sean Cogan</author>
// <author>Waleed Johnson</author>
// <author>Kevin Sonnen</author>
// <author>Luke Westby</author>

namespace MapTheStars.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a user of the site
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Primary Key identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// User's public email address
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// User's public username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// User's private email to retrieve a Gravatar profile picture
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string GravatarEmail { get; set; }
    }
}