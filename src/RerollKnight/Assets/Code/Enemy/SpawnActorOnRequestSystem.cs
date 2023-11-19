using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class SpawnActorOnRequestSystem : FulfillRequestSystemBase<SpawnActor>
	{
		private readonly IAssetsService _assets;

		public SpawnActorOnRequestSystem(Contexts contexts, IAssetsService assets)
			: base(contexts)
		{
			_assets = assets;
		}

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<CoordinatesRequest>());

			SpawnPrefab(request)
				.Replace<Component.Coordinates, Coordinates>(request.Get<CoordinatesRequest>().Value)
				.Is<Actor>(true);
		}

		private Entity<GameScope> SpawnPrefab(Entity<RequestScope> request)
			=> _assets.SpawnBehaviour(request.Get<Prefab>().Value).Entity;
	}
}