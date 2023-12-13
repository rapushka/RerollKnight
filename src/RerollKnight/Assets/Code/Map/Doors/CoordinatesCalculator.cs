using System;
using Entitas.Generic;

namespace Code
{
	public class CoordinatesCalculator
	{
		private readonly GenerationConfig _generationConfig;

		public CoordinatesCalculator(GenerationConfig generationConfig)
		{
			_generationConfig = generationConfig;
		}

		public Coordinates TransitionBetweenRooms(Entity<GameScope> room1, Entity<GameScope> room2)
		{
			var lengthOfSide = _generationConfig.RoomSizes.Column; // TODO: now will work only for square levels
			var center = lengthOfSide / 2;                         // TODO: and with odd length

			var direction = room1.GetCoordinates() - room2.GetCoordinates();

			return direction == (1, 0) ? new Coordinates(-1, center)           // top left
				: direction == (0, 1)  ? new Coordinates(center, -1)           // top right
				: direction == (0, -1) ? new Coordinates(lengthOfSide, center) // down left
				: direction == (-1, 0) ? new Coordinates(center, lengthOfSide) // down right
				                         : throw CantCreateDoorException(room1, room2);
		}

		private InvalidOperationException CantCreateDoorException(Entity<GameScope> room1, Entity<GameScope> room2)
			=> new($"The Room {room1} isn't neighbor for the {room2}");
	}
}