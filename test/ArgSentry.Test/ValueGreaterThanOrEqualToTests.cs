using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace ArgSentry.Test
{
    [TestClass]
    public class ValueGreaterThanOrEqualToTests
    {
        [TestMethod]
        public void ValueGreaterThanOrEqualTo_WhenGreaterThan_ShouldThrow()
        {
            // Arrange
            const int obj = 10;
            const int mustBeLessThan = 5;
            var expectedMessage = $"Value must be less than {mustBeLessThan}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.ValueGreaterThanOrEqualTo(obj, mustBeLessThan, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void ValueGreaterThanOrEqualTo_WhenEqualTo_ShouldThrow()
        {
            // Arrange
            const int obj = 5;
            const int mustBeLessThan = 5;
            var expectedMessage = $"Value must be less than {mustBeLessThan}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.ValueGreaterThanOrEqualTo(obj, mustBeLessThan, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void ValueGreaterThanOrEqualTo_WhenLessThan_ShouldNotThrow()
        {
            // Arrange
            const int obj = 4;
            const int mustBeLessThan = 5;

            // Act
            Action act = () => Prevent.ValueGreaterThanOrEqualTo(obj, mustBeLessThan, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }
    }
}