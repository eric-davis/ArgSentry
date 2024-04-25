using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class NullGuidTests
{
    [TestMethod]
    public void NullGuid_WhenValueIsNull_ShouldThrow()
    {
        // Arrange
        Guid? obj = null;
        var expectedMessage = $"Value cannot be null. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullGuid(obj, nameof(obj));

        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullGuid_WhenValueIsValid_ShouldNotThrow()
    {
        // Arrange
        var obj = Guid.Parse("18413dc6-df4b-4631-a4aa-146ad22c0319");

        // Act
        Action act = () => Prevent.NullGuid(obj, nameof(obj));

        //Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void NullGuid_WhenValueIsEmpty_ShouldNotThrow()
    {
        // Arrange
        var obj = Guid.Empty;

        // Act
        Action act = () => Prevent.NullGuid(obj, nameof(obj));

        //Assert
        act.Should().NotThrow();
    }
}