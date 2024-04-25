using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class EmptyOrWhiteSpaceStringTests
{
    [TestMethod]
    public void EmptyOrWhiteSpaceString_WhenValueIsEmpty_ShouldThrow()
    {
        // Arrange
        var obj = string.Empty;
        var expectedMessage = $"Value cannot be empty or white space. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.EmptyOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void EmptyOrWhiteSpaceString_WhenValueIsWhitespace_ShouldThrow()
    {
        // Arrange
        var obj = "  ";
        var expectedMessage = $"Value cannot be empty or white space. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.EmptyOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void EmptyOrWhiteSpaceString_WhenValueIsNull_ShouldNotThrow()
    {
        // Arrange
        string obj = null;

        // Act
        // ReSharper disable once ExpressionIsAlwaysNull
        Action act = () => Prevent.EmptyOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void EmptyOrWhiteSpaceString_WhenValueIsValid_ShouldNotThrow()
    {
        // Arrange
        const string obj = "test";

        // Act
        Action act = () => Prevent.EmptyOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }
}