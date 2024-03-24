using FluentAssertions;
using NUnit.Framework;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class CoordinatesTests
	{
		[Test]
		public void _010_WhenSameCoordinates_AndLayerIsDefault_ThenShouldBeEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 0, Coordinates.Layer.Default);
			var coordinates2 = new Coordinates(1, 0, Coordinates.Layer.Default);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(true, "Compared {0} and {0}", coordinates1, coordinates2);
		}

		[Test]
		public void _020_WhenDiffCoordinates_AndLayerIsDefault_ThenShouldBeNotEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 0, Coordinates.Layer.Default);
			var coordinates2 = new Coordinates(0, 1, Coordinates.Layer.Default);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(false, "Compared {0} and {0}", coordinates1, coordinates2);
		}

		[Test]
		public void _030_WhenSameCoordinates_AndLayerIsNone_ThenShouldBeNotEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 2);
			var coordinates2 = new Coordinates(1, 2);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(false, "Compared {0} and {0}", coordinates1, coordinates2);
		}

		[Test]
		public void _035_WhenDiffCoordinates_AndLayerIsNone_ThenShouldBeNotEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 2);
			var coordinates2 = new Coordinates(3, 5);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(false, "Compared {0} and {0}", coordinates1, coordinates2);
		}

		[Test]
		public void _040_WhenSameCoordinates_AndDiffLayers_ThenShouldBeNotEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 2, Coordinates.Layer.Default);
			var coordinates2 = new Coordinates(1, 2, Coordinates.Layer.Bellow);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(false, "Compared {0} and {0}", coordinates1, coordinates2);
		}

		[Test]
		public void _050_WhenSameCoordinates_AndSomeLayerIsIgnore_ThenShouldBeEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 2, Coordinates.Layer.Default);
			var coordinates2 = new Coordinates(1, 2, Coordinates.Layer.Ignore);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(true, "Compared {0} and {0}", coordinates1, coordinates2);
		}

		[Test]
		public void _060_WhenDiffCoordinates_AndSomeLayerIsIgnore_ThenShouldBeNotEquals()
		{
			// Arrange.
			var coordinates1 = new Coordinates(1, 2, Coordinates.Layer.Default);
			var coordinates2 = new Coordinates(4, 2, Coordinates.Layer.Ignore);

			// Act.
			var equals = coordinates1 == coordinates2;

			// Assert.
			equals.Should().Be(false, "Compared {0} and {0}", coordinates1, coordinates2);
		}
	}
}