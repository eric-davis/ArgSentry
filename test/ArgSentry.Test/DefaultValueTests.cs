using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace ArgSentry.Test
{
    using System.Collections.Generic;

    [TestClass]
    public class DefaultValueTests
    {
        [TestMethod]
        public void DefaultValue_WhenIntValueIsDefault_ShouldThrow()
        {
            // Arrange
            var value = default(int);
            var expectedMessage = "Parameter cannot be default type value. (Parameter 'value')";

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(value));
        }

        [TestMethod]
        public void DefaultValue_WhenStringValueIsDefault_ShouldThrow()
        {
            // Arrange
            var value = default(string);
            var expectedMessage = "Parameter cannot be default type value. (Parameter 'value')";

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(value));
        }

        [TestMethod]
        public void DefaultValue_WhenGuidValueIsDefault_ShouldThrow()
        {
            // Arrange
            var value = default(Guid);
            var expectedMessage = "Parameter cannot be default type value. (Parameter 'value')";

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(value));
        }

        [TestMethod]
        public void DefaultValue_WhenObjectValueIsDefault_ShouldThrow()
        {
            // Arrange
            var value = default(List<string>);
            var expectedMessage = "Parameter cannot be default type value. (Parameter 'value')";

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage(expectedMessage)
                .And.ParamName.Should().Be(nameof(value));
        }

        [TestMethod]
        public void DefaultValue_WhenIntValueIsNotDefault_ShouldNotThrow()
        {
            // Arrange
            var value = 123;

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [TestMethod]
        public void DefaultValue_WhenStringValueIsNotDefault_ShouldNotThrow()
        {
            // Arrange
            var value = "Testing...";

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [TestMethod]
        public void DefaultValue_WhenGuidValueIsNotDefault_ShouldNotThrow()
        {
            // Arrange
            var value = Guid.NewGuid();

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [TestMethod]
        public void DefaultValue_WhenObjectValueIsNotDefault_ShouldNotThrow()
        {
            // Arrange
            var value = new List<string>();

            // Act
            Action act = () => Prevent.DefaultValue(value, nameof(value));

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }
    }
}