using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class NullOrEmptyGuidTests
{
    [TestMethod]
    public void NullOrEmptyGuid_WhenValueIsNull_ShouldThrow()
    {
        // Arrange
        Guid? obj = null;
        var expectedMessage = $"Value cannot be null or empty. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullOrEmptyGuid(obj, nameof(obj));

        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullOrEmptyGuid_WhenValueIsEmpty_ShouldThrow()
    {
        // Arrange
        var obj = Guid.Empty;
        var expectedMessage = $"Value cannot be null or empty. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullOrEmptyGuid(obj, nameof(obj));

        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullOrEmptyGuid_WhenValueIsValid_ShouldNotThrow()
    {
        // Arrange
        var obj = Guid.Parse("18413dc6-df4b-4631-a4aa-146ad22c0319");

        // Act
        Action act = () => Prevent.NullOrEmptyGuid(obj, nameof(obj));

        //Assert
        act.Should().NotThrow();
    }
}