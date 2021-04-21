using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopicTweets.Controllers;

namespace TopicTweetsTests.Controllers
{
    [TestClass]
    public class HealthCheckControllerTests
    {
        [TestMethod]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var healthCheckController = new HealthCheckController();

            // Act
            var result = healthCheckController.Index();

            // Assert
            StatusCodeResult statusResult = result as StatusCodeResult;
            Assert.IsNotNull(statusResult);
            Assert.AreEqual(200, statusResult.StatusCode);
        }
    }
}