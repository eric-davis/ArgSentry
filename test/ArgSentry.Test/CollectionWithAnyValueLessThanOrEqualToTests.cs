using System;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming
namespace ArgSentry.Test
{
    [TestClass]
    public class CollectionWithAnyValuesLessThanOrEqualToTests
    {
        [TestMethod]
        public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionIsValid_ShouldNotThrow()
        {
            // Arrange
            const int MustBeGreaterThan = 0;
            var obj = new[] { 1, 2, 3, 4, 5, 6 };

            // Act
            Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(obj, MustBeGreaterThan, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionIsNull_ShouldNotThrow()
        {
            // Arrange
            const int MustBeGreaterThan = 0;
            int[] nullCollection = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(nullCollection, MustBeGreaterThan, nameof(nullCollection));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionContainsMinValue_ShouldThrow()
        {
            // Arrange
            const int MustBeGreaterThan = 1;
            var obj = new[] { 1, 2, 3, 4, 5, 6 };

            var expectedMessage =
                $"All collection values must be greater than {MustBeGreaterThan}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(obj, MustBeGreaterThan, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void CollectionWithAnyValuesLessThanOrEqualTo_WhenCollectionContainsValueLessThanMinValue_ShouldThrow()
        {
            // Arrange
            const int MustBeGreaterThan = 3;
            var obj = new[] { 1, 2, 3, 4, 5, 6 };

            var expectedMessage =
                $"All collection values must be greater than {MustBeGreaterThan}. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.CollectionWithAnyValuesLessThanOrEqualTo(obj, MustBeGreaterThan, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }
    }
}
