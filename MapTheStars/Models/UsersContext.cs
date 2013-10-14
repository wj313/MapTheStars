// <copyright file="UsersContext.cs" company="MapTheStars">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author>Sean Cogan</author>
// <author>Waleed Johnson</author>
// <author>Kevin Sonnen</author>
// <author>Luke Westby</author>

namespace MapTheStars.Models
{
    using System;
    using System.Data.Entity;

    /// <summary>
    /// Serves the Users table from the database
    /// </summary>
    public class UsersContext : DbContext
    {
        /// <summary>
        /// Gets or sets the Users database set from which UserItem models are served
        /// </summary>
        public DbSet<UserModel> Users { get; set; }
    }
}