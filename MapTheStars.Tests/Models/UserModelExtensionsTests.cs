namespace MapTheStars.Tests.Models
{
    using System;
    using MapTheStars.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserModelExtensionsTests
    {
        private TestContext testContext;
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [TestMethod]
        public void TestGenerateGravatarUrl()
        {
            TestContext.WriteLine("TestGenerateGravatarUrl ----------------------------------------------");
            const string testEmail = "test@test.com";
            const string expectedUrl = "http://www.gravatar.com/avatar/b642b4217b34b1e8d3bd915fc65c4452.jpg";
            var testUser = new UserModel() { GravatarEmail = testEmail };
            var actualUrl = testUser.GenerateGravatarUrl();
            Assert.AreEqual<string>(expectedUrl, actualUrl, "- Generated url should be equal to the one generated and verified online");
        }
    }
}
