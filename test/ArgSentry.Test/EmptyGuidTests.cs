using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace ArgSentry.Test
{
    [TestClass]
    public class EmptyGuidTests
    {
        [TestMethod]
        public void EmptyGuid_WhenValueIsEmpty_ShouldThrow()
        {
            // Arrange
            var obj = Guid.Empty;
            var expectedMessage =
                $"Value cannot be empty. (Parameter '{nameof(obj)}')";

            // Act
            Action act = () => Prevent.EmptyGuid(obj, nameof(obj));

            //Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(obj));
        }

        [TestMethod]
        public void EmptyGuid_WhenValueIsValid_ShouldNotThrow()
        {
            // Arrange
            var obj = Guid.Parse("18413dc6-df4b-4631-a4aa-146ad22c0319");

            // Act
            Action act = () => Prevent.EmptyGuid(obj, nameof(obj));

            //Assert
            act.Should().NotThrow();
        }
    }
}