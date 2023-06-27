using Entitas;
using UnityEngine;

namespace Code
{
	public sealed class SpawnDebugChipSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnDebugChipSystem(Contexts contexts) => _contexts = contexts;

		public void Initialize()
		{
			var chip = SpawnChip(at: new Vector3(2.9f, 3f, 2.9f));
		}

		private static GameEntityBehaviour SpawnChip(Vector3 at)
			=> ServicesMediator.Assets.SpawnBehaviour(ChipPrefab, at);

		private static GameEntityBehaviour ChipPrefab => ServicesMediator.Resources.ChipPrefab;
	}
}