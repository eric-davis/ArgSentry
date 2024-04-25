using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class ValueLessThanTests
{
    [TestMethod]
    public void ValueLessThan_WhenLessThan_ShouldThrow()
    {
        // Arrange
        const int obj = 4;
        const int mustBeGreaterThanOrEqualTo = 5;
        var expectedMessage = $"Value must be greater than or equal to {mustBeGreaterThanOrEqualTo}. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.ValueLessThan(obj, mustBeGreaterThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void ValueLessThan_WhenEqualTo_ShouldNotThrow()
    {
        // Arrange
        const int obj = 5;
        const int mustBeGreaterThanOrEqualTo = 5;

        // Act
        Action act = () => Prevent.ValueLessThan(obj, mustBeGreaterThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void ValueLessThan_WhenGreaterThan_ShouldNotThrow()
    {
        // Arrange
        const int obj = 6;
        const int mustBeGreaterThanOrEqualTo = 5;

        // Act
        Action act = () => Prevent.ValueLessThan(obj, mustBeGreaterThanOrEqualTo, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }
}