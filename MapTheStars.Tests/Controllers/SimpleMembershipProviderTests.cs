// <copyright file="SimpleMembershipProviderTests.cs" company="MapTheStars">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author>Sean Cogan</author>
// <author>Waleed Johnson</author>
// <author>Kevin Sonnen</author>
// <author>Luke Westby</author>

namespace MapTheStars.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Effort;
    using MapTheStars.Models;
    using MapTheStars.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SimpleMembershipProviderTests
    {
        [TestMethod]
        public void TestValidateUser()
        {
            const string username = "TestUser1";
            const string email = username + "@test.com";
            const string correctPassword = "TestPassword1";
            const string incorrectPassword = "TheWrongPassword";

            var connection = DbConnectionFactory.CreateTransient();
            var context = new UsersContext(connection);

            var newUser = new UserModel()
            {
                Username = username,
                Email = email,
                Password = correctPassword
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            var provider = new SimpleMembershipProvider(connection);

            var isValidated = provider.ValidateUser(username, incorrectPassword);

            Assert.IsFalse(isValidated);

            isValidated = provider.ValidateUser(username, correctPassword);

            Assert.IsTrue(isValidated);
        }
    }
}
