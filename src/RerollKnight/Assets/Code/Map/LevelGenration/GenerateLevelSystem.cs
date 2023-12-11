using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class GenerateLevelSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly LevelFactory _levelFactory;

		[Inject]
		public GenerateLevelSystem(Contexts contexts, LevelFactory levelFactory)
		{
			_contexts = contexts;
			_levelFactory = levelFactory;
		}

		public void Initialize()
		{
			_levelFactory.Create();
			// Add<SpawnFieldSystem>();
			// Add<SpawnActorsSystem>();
			// Add<SpawnWallsSystem>();
		}
	}

	public class LevelFactory
	{
		private readonly RoomFactory _roomFactory;
		private GenerationConfig _generationConfig;

		[Inject]
		public LevelFactory(RoomFactory roomFactory, GenerationConfig generationConfig)
		{
			_roomFactory = roomFactory;
			_generationConfig = generationConfig;
		}

		public void Create()
		{
			var sizes = _generationConfig.LevelSizes; // TODO: Layer.Ignore in inspector
			foreach (var coordinates in sizes) { }
		}
	}

	public class RoomFactory { }

	public static class CoordinatesEnumeratorExtensions
	{
		public static CoordinatesEnumerator GetEnumerator(this Coordinates @this)
			=> new CoordinatesEnumerator(@this);
	}

	public class CoordinatesEnumerator : IEnumerator<Coordinates>
	{
		private readonly Coordinates _end;

		public CoordinatesEnumerator(Coordinates coordinates)
		{
			_end = coordinates.Add(column: -1, row: -1);
			Current = new Coordinates(0, 0, Coordinates.Layer.Ignore);
		}

		public Coordinates Current { get; private set; }

		public bool MoveNext()
		{
			Current = Current!.Column < _end.Column
				? Current.Add(column: 1)
				: Current.WithColumn(0).Add(row: 1);

			return Current!.Column < _end.Column || Current.Row < _end.Row;
		}

		public void Reset()
		{
			throw new System.NotImplementedException();
		}

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			Reset();
		}
	}
}