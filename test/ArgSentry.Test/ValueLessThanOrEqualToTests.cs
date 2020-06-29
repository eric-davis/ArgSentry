using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace ArgSentry.Test
{
    [TestClass]
    public class ValueLessThanOrEqualToTests
    {
        [TestMethod]
        public void ValueLessThanOrEqualTo_WhenLessThan_ShouldThrow()
        {
            // Arrange
            const int obj = 4;
            const int mustBeGreaterThan = 5;
            var expectedMessage =
                $"Value must be greater than {mustBeGreaterThan}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.ValueLessThanOrEqualTo(obj, mustBeGreaterThan, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void ValueLessThanOrEqualTo_WhenEqualTo_ShouldThrow()
        {
            // Arrange
            const int obj = 5;
            const int mustBeGreaterThan = 5;
            var expectedMessage =
                $"Value must be greater than {mustBeGreaterThan}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.ValueLessThanOrEqualTo(obj, mustBeGreaterThan, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void ValueLessThanOrEqualTo_WhenGreaterThan_ShouldNotThrow()
        {
            // Arrange
            const int obj = 6;
            const int mustBeGreaterThan = 5;

            // Act
            Action act = () => Prevent.ValueLessThanOrEqualTo(obj, mustBeGreaterThan, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }
    }
}