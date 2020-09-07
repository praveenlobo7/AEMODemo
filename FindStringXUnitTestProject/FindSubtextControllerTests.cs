using FindStringCoreWebapplication.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FindStringXUnitTestProject
{
    public class FindSubtextControllerTests
    {
        [Trait("Find subtext", "Simple")]
        [Theory(DisplayName = "Find subtext")]
        [InlineData("Hello how are you. how is life?", "How", "6,19")]
        public void Get(string text, string subText,string expectedResult)
        {
            var mock = new Mock<ILogger<FindSubtextController>>();
            ILogger<FindSubtextController> logger = mock.Object;

            // 1. Arrange
            var cs = new FindSubtextController(logger);

            // 2. Act 
            var result = cs.Get(text, subText);

            // 3. Assert 
            Assert.Equal(expectedResult, result);
        }
    }
}
