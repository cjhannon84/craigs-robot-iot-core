using CraigsRobot.Core.Helpers;
using CraigsRobot.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CraigsRobot.Core.Tests.Helpers
{
    [TestClass]
    public class ControllerDirectionHelpersTests
    {
        [TestClass]
        public class GetControllerDirection
        {
            [TestMethod]
            public void ReturnsLeftCorrectly()
            {
                Assert.AreEqual(ControllerDirectionEnum.Left, ControllerDirectionHelpers.GetControllerDirection(-1, 0));
            }

            [TestMethod]
            public void ReturnsRightCorrectly()
            {
                Assert.AreEqual(ControllerDirectionEnum.Right, ControllerDirectionHelpers.GetControllerDirection(1, 0));
            }

            [TestMethod]
            public void ReturnsReverseCorrectly()
            {
                Assert.AreEqual(ControllerDirectionEnum.Reverse, ControllerDirectionHelpers.GetControllerDirection(0, -1));
            }

            [TestMethod]
            public void ReturnsForwardCorrectly()
            {
                Assert.AreEqual(ControllerDirectionEnum.Forwards, ControllerDirectionHelpers.GetControllerDirection(0, 1));
            }
        }
    }
}
