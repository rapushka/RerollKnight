using Entitas;
using UnityEngine;

namespace Code
{
	public sealed class SpawnDebugChipSystem : IInitializeSystem
	{
		// ReSharper disable once NotAccessedField.Local - for consistent Adding
		private readonly Contexts _contexts;

		public SpawnDebugChipSystem(Contexts contexts) => _contexts = contexts;

		public void Initialize()
		{
			SpawnChip(at: new Vector3(1.9f, 3f, 3.9f));
			SpawnChip(at: new Vector3(2.9f, 3f, 2.9f));
		}

		private static void SpawnChip(Vector3 at) => ServicesMediator.Assets.SpawnBehaviour(ChipPrefab, at);

		private static GameEntityBehaviour ChipPrefab => ServicesMediator.Resources.ChipPrefab;
	}
}