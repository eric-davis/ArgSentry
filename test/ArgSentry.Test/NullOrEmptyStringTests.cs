using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace ArgSentry.Test
{
    [TestClass]
    public class NullOrEmptyStringTests
    {
        [TestMethod]
        public void NullOrEmptyString_WhenNull_ShouldThrow()
        {
            // Arrange
            string obj = null;
            var expectedMessage = $"Value cannot be null or empty. (Parameter '{nameof(obj)}')";

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action act = () => Prevent.NullOrEmptyString(obj, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void NullOrEmptyString_WhenEmpty_ShouldThrow()
        {
            // Arrange
            var obj = string.Empty;
            var expectedMessage = $"Value cannot be null or empty. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.NullOrEmptyString(obj, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void NullOrEmptyString_WhenWhitespace_ShouldNotThrow()
        {
            // Arrange
            var obj = " ";

            // Act
            Action act = () => Prevent.NullOrEmptyString(obj, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void NullOrEmptyString_WhenValid_ShouldNotThrow()
        {
            // Arrange
            var obj = "test";

            // Act
            Action act = () => Prevent.NullOrEmptyString(obj, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }
    }
}