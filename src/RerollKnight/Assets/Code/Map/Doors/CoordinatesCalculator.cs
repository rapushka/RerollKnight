using System;
using Entitas;
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

		private int LengthOfSide => _generationConfig.RoomSizes.Column; // TODO: now will work only for square levels

		private int CenterCoordinates => LengthOfSide / 2; // TODO: and with odd length

		private Coordinates TopLeft   => new(-1, CenterCoordinates);
		private Coordinates ToRight   => new(CenterCoordinates, -1);
		private Coordinates DownLeft  => new(LengthOfSide, CenterCoordinates);
		private Coordinates DownRight => new(CenterCoordinates, LengthOfSide);

		public Coordinates TransitionBetweenRooms(Entity<GameScope> room1, Entity<GameScope> room2)
		{
			var direction = room1.GetCoordinates() - room2.GetCoordinates();
			return DirectionToCoordinates(room1, room2, direction);
		}

		private Coordinates DirectionToCoordinates(Entity room1, Entity room2, Coordinates direction)
			=> direction == (1, 0)     ? TopLeft
				: direction == (0, 1)  ? ToRight
				: direction == (0, -1) ? DownLeft
				: direction == (-1, 0) ? DownRight
				                         : throw CantCreateDoorException(room1, room2);

		private InvalidOperationException CantCreateDoorException(Entity room1, Entity room2)
			=> new($"The Room {room1} isn't neighbor for the {room2}");
	}
}