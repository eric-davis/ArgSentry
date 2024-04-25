using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class ValueGreaterThanTests
{
    [TestMethod]
    public void ValueGreaterThan_WhenGreaterThan_ShouldThrow()
    {
        // Arrange
        const int obj = 10;
        const int mustBeLessThanOrEqualTo = 5;
        var expectedMessage =
            $"Value must be less than or equal to {mustBeLessThanOrEqualTo}. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.ValueGreaterThan(obj, mustBeLessThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void ValueGreaterThan_WhenEqual_ShouldNotThrow()
    {
        // Arrange
        const int obj = 5;
        const int mustBeLessThanOrEqualTo = 5;

        // Act
        Action act = () => Prevent.ValueGreaterThan(obj, mustBeLessThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void ValueGreaterThan_WhenLessThan_ShouldNotThrow()
    {
        // Arrange
        const int obj = 4;
        const int mustBeLessThanOrEqualTo = 5;

        // Act
        Action act = () => Prevent.ValueGreaterThan(obj, mustBeLessThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void ValueGreaterThan_WhenValidUsingNegatives_ShouldNotThrow()
    {
        // Arrange
        const int obj = -6;
        const int mustBeLessThanOrEqualTo = -5;

        // Act
        Action act = () => Prevent.ValueGreaterThan(obj, mustBeLessThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }
}