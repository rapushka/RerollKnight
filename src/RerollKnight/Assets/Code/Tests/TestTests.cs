using FluentAssertions;
using NUnit.Framework;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class TestTests
	{
		[Test]
		public void WhenOne_AndOne_ThenTwo()
		{
			// Arrange.
			var firstNumber = 1;
			var secondNumber = 1;

			// Act.
			var sum = firstNumber + secondNumber;

			// Assert.
			sum.Should().Be(2);
		}
	}
}