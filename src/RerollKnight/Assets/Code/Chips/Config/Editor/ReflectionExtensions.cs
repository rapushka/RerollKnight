using System;
using System.Reflection;

namespace Code.Editor
{
	public static class ReflectionExtensions
	{
		public static void SetPrivatePropertyValue<T>(this object @this, string propertyName, T value)
		{
			var type = @this.GetType();
			var propertyInfo = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
			                   ?? throw NoPropertyException(propertyName, type);

			propertyInfo.SetValue(@this, value);
		}

		private static ArgumentException NoPropertyException(string propertyName, Type type)
			=> new($"Property '{propertyName}' not found in type '{type}'.");
	}
}