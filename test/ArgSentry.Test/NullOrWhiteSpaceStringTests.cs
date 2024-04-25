using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class NullOrWhiteSpaceStringTests
{
    [TestMethod]
    public void NullOrWhiteSpaceString_WhenNull_ShouldThrow()
    {
        // Arrange
        string obj = null;
        var expectedMessage = $"Value cannot be null, empty, or white space. (Parameter '{nameof(obj)}')";

        // Act
        // ReSharper disable once ExpressionIsAlwaysNull
        Action act = () => Prevent.NullOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullOrWhiteSpaceString_WhenWhitespace_ShouldThrow()
    {
        // Arrange
        var obj = " ";
        var expectedMessage = $"Value cannot be null, empty, or white space. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullOrWhiteSpaceString_WhenEmptyString_ShouldNotThrow()
    {
        // Arrange
        var obj = string.Empty;
        var expectedMessage = $"Value cannot be null, empty, or white space. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullOrWhiteSpaceString_WhenValid_ShouldNotThrow()
    {
        // Arrange
        var obj = "test";

        // Act
        Action act = () => Prevent.NullOrWhiteSpaceString(obj, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }
}