using FluentAssertions;
using UnityEngine;

namespace Code.Editor.Tests
{
	public static class Vector3FluentAssertionsExtensions
	{
		public static Vector3Assertions Should(this Vector3 vector) => new(vector);
	}

	public class Vector3Assertions
	{
		private readonly Vector3 _vector;

		public Vector3Assertions(Vector3 vector)
		{
			_vector = vector;
		}

		public void Be(Vector3 expected)
		{
			_vector.x.Should().Be(expected.x);
			_vector.y.Should().Be(expected.y);
			_vector.z.Should().Be(expected.z);
		}

		public void BeApproximately(Vector3 expected, float tolerance)
		{
			_vector.x.Should().BeApproximately(expected.x, tolerance);
			_vector.y.Should().BeApproximately(expected.y, tolerance);
			_vector.z.Should().BeApproximately(expected.z, tolerance);
		}
	}
}