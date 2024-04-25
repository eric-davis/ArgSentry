using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgSentry.Test;

[TestClass]
[ExcludeFromCodeCoverage]
public class CollectionWithAnyValuesLessThanOrEqualToTests
{
    [TestMethod]
    public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionIsValid_ShouldNotThrow()
    {
        // Arrange
        const int mustBeGreaterThan = 0;
        var obj = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(obj, mustBeGreaterThan, nameof(obj));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionIsNull_ShouldNotThrow()
    {
        // Arrange
        const int mustBeGreaterThan = 0;
        int[] nullCollection = null;

        // Act
        // ReSharper disable once ExpressionIsAlwaysNull
        Action act = () =>
            Prevent.CollectionWithAnyValuesLessThanOrEqualTo(nullCollection, mustBeGreaterThan, nameof(nullCollection));

        // Assert
        act.Should().NotThrow();
    }

    [TestMethod]
    public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionContainsMinValue_ShouldThrow()
    {
        // Arrange
        const int mustBeGreaterThan = 1;
        var obj = new[] { 1, 2, 3, 4, 5, 6 };

        var expectedMessage = $"All collection values must be greater than {mustBeGreaterThan}. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(obj, mustBeGreaterThan, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }

    [TestMethod]
    public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionContainsValueLessThanMinValue_ShouldThrow()
    {
        // Arrange
        const int mustBeGreaterThan = 3;
        var obj = new[] { 1, 2, 3, 4, 5, 6 };

        var expectedMessage = $"All collection values must be greater than {mustBeGreaterThan}. (Parameter '{nameof(obj)}')";

        // Act
        Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(obj, mustBeGreaterThan, nameof(obj));

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage(expectedMessage)
            .And.ParamName.Should().Be(nameof(obj));
    }
}