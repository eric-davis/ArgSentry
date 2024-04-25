using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class NullObjectTests
{
    [TestMethod]
    public void NullObject_WhenNull_ShouldThrow()
    {
        // Arrange
        string obj = null;
        var expectedMessage = $"Value cannot be null. (Parameter '{nameof(obj)}')";

        // Act
        // ReSharper disable once ExpressionIsAlwaysNull
        Action act = () => Prevent.NullObject(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullObject_WhenValid_ShouldNotThrow()
    {
        // Arrange
        var obj = string.Empty;

        // Act
        Action act = () => Prevent.NullObject(obj, nameof(obj));

        // Assert
        act.Should().NotThrow<ArgumentNullException>();
    }
}