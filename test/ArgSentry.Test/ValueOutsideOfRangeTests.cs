using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace ArgSentry.Test
{
    [TestClass]
    public class ValueOutsideOfRangeTests
    {
        [TestMethod]
        public void ValueOutsideOfRange_WhenBeyondRange_ShouldThrow()
        {
            // Arrange
            const int obj = 21;
            const int rangeStart = 10;
            const int rangeEnd = 20;
            var expectedMessage =
                $"Value outside of specified range; {rangeStart} - {rangeEnd}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.ValueOutsideOfRange(obj, rangeStart, rangeEnd, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void ValueOutsideOfRange_WhenBeforeRange_ShouldThrow()
        {
            // Arrange
            const int obj = 9;
            const int rangeStart = 10;
            const int rangeEnd = 20;
            var expectedMessage =
                $"Value outside of specified range; {rangeStart} - {rangeEnd}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.ValueOutsideOfRange(obj, rangeStart, rangeEnd, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void ValueOutsideOfRange_WhenAtBeginningOfRange_ShouldNotThrow()
        {
            // Arrange
            const int obj = 10;
            const int rangeStart = 10;
            const int rangeEnd = 20;

            // Act
            Action act = () => Prevent.ValueOutsideOfRange(obj, rangeStart, rangeEnd, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void ValueOutsideOfRange_WhenAtEndOfRange_ShouldNotThrow()
        {
            // Arrange
            const int obj = 20;
            const int rangeStart = 10;
            const int rangeEnd = 20;

            // Act
            Action act = () => Prevent.ValueOutsideOfRange(obj, rangeStart, rangeEnd, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void ValueOutsideOfRange_WhenWithinRange_ShouldNotThrow()
        {
            // Arrange
            const int obj = 15;
            const int rangeStart = 10;
            const int rangeEnd = 20;

            // Act
            Action act = () => Prevent.ValueOutsideOfRange(obj, rangeStart, rangeEnd, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }
    }
}