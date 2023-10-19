using System;

namespace Code
{
	public static class CoordinatesExtensions
	{
		public static Coordinates GetCoordinates(this GameEntity @this)
		{
			var hasBoth = @this.hasCoordinates && @this.hasCoordinatesUnderField;

			return hasBoth                       ? ThrowBothCoordinates()
				: @this.hasCoordinates           ? @this.coordinates.Value
				: @this.hasCoordinatesUnderField ? @this.coordinatesUnderField.Value
				                                   : ThrowNoCoordinates();
		}

		private static Coordinates ThrowBothCoordinates()
		{
			var message = "Entity can't have both "
			              + $"{nameof(CoordinatesComponent)} and {nameof(CoordinatesUnderFieldComponent)}";
			throw new InvalidOperationException(message);
		}

		private static Coordinates ThrowNoCoordinates()
			=> throw new InvalidOperationException("Entity has no coordinates");
	}
}