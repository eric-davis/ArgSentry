﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class NullOrEmptyCollectionTests
{
    [TestMethod]
    public void NullOrEmptyCollection_WhenCollectionIsValid_ShouldNotThrow()
    {
        // Arrange
        var obj = new List<string> { "This", "is", "a", "test" };

        // Act
        Action act = () => Prevent.NullOrEmptyCollection(obj, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void NullOrEmptyCollection_WhenCollectionIsNull_ShouldThrow()
    {
        // Arrange
        List<string> obj = null;
        var expectedMessage = $"Collection cannot be null or empty. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullOrEmptyCollection(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage(expectedMessage).And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void NullOrEmptyCollection_WhenCollectionIsEmpty_ShouldThrow()
    {
        // Arrange
        var obj = new List<string>();
        var expectedMessage = $"Collection cannot be null or empty. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.NullOrEmptyCollection(obj, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage(expectedMessage).And.ParamName.Should().Be(nameof(obj));
    }
}