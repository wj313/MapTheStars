// <copyright file="SimpleMembershipProviderTests.cs" company="MapTheStars">
// Copyright (c) 2013 All Rights Reserved
// </copyright>
// <author>Sean Cogan</author>
// <author>Waleed Johnson</author>
// <author>Kevin Sonnen</author>
// <author>Luke Westby</author>

namespace MapTheStars.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Web.Security;
    using MapTheStars.Models;

    /// <summary>
    /// Implements a MembershipProvider class which allows customization of
    /// login behaviors with easy integration into IIS
    /// </summary>
    class SimpleMembershipProvider : MembershipProvider
    {
        /// <summary>
        /// User database access
        /// </summary>
        private UsersContext usersContext;

        /// <summary>
        /// Default constructor builds a new UsersContext with default Enity connection
        /// </summary>
        public SimpleMembershipProvider()
        {
            usersContext = new UsersContext();
        }

        /// <summary>
        /// Testing constructor sets DbConnection for UsersContext directly
        /// </summary>
        /// <param name="connection">The DbConnection class to use</param>
        internal SimpleMembershipProvider(DbConnection connection)
        {
            usersContext = new UsersContext(connection);
        }

        /// <summary>
        /// Validates an input username and password against the stored values in the database
        /// </summary>
        /// <param name="username">The plaintext username</param>
        /// <param name="password">The plaintext password</param>
        /// <returns>Whether or not the parameters match a user</returns>
        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            var user = (from u in usersContext.Users
                        where String.Compare(u.Username, username, StringComparison.OrdinalIgnoreCase) == 0
                                && String.Compare(u.Password, password, StringComparison.OrdinalIgnoreCase) == 0
                        select u).FirstOrDefault();

            return user != null;
        }

        #region Unimplemented MembershipProvider Members

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
