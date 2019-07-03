using System;
using System.Collections.Generic;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming
namespace ArgSentry.Test
{
    [TestClass]
    public class NullOrEmptyReadOnlyCollectionTests
    {
        [TestMethod]
        public void NullOrEmptyReadOnlyCollection_WhenCollectionIsValid_ShouldNotThrow()
        {
            // Arrange
            var obj = new List<string> { "This", "is", "a", "test" }.AsReadOnly();

            // Act
            Action act = () => Prevent.NullOrEmptyReadOnlyCollection(obj, nameof(obj));

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void NullOrEmptyReadOnlyCollection_WhenCollectionIsNull_ShouldThrow()
        {
            // Arrange
            IReadOnlyCollection<string> obj = null;
            var expectedMessage = $"Collection cannot be null or empty.\r\nParameter name: {nameof(obj)}";

            // Act
            Action act = () => Prevent.NullOrEmptyReadOnlyCollection(obj, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage(expectedMessage).And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void NullOrEmptyReadOnlyCollection_WhenCollectionIsEmpty_ShouldThrow()
        {
            // Arrange
            var obj = new List<string>().AsReadOnly();
            var expectedMessage = $"Collection cannot be null or empty.\r\nParameter name: {nameof(obj)}";

            // Act
            Action act = () => Prevent.NullOrEmptyReadOnlyCollection(obj, nameof(obj));

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage(expectedMessage).And.ParamName.Should().Be(nameof(obj));
        }
    }
}
