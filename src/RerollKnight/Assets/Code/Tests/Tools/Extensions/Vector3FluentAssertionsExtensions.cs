using FluentAssertions;
using UnityEngine;

namespace Code.Editor.Tests
{
	public static class Vector3FluentAssertionsExtensions
	{
		public static void ShouldBeApproximately(this Vector3 actual, Vector3 expected, float tolerance)
		{
			actual.x.Should().BeApproximately(expected.x, tolerance);
			actual.y.Should().BeApproximately(expected.y, tolerance);
			actual.z.Should().BeApproximately(expected.z, tolerance);
		}
	}
}