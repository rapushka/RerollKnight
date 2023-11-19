using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class SpawnActorOnRequestSystem : FulfillRequestSystemBase<SpawnActor>
	{
		private readonly ServicesMediator _servicesMediator;
		private readonly IAssetsService _assets;

		public SpawnActorOnRequestSystem(Contexts contexts, ServicesMediator servicesMediator, IAssetsService assets)
			: base(contexts)
		{
			_servicesMediator = servicesMediator;
			_assets = assets;
		}

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<CoordinatesRequest>());

			var actor = _servicesMediator.SpawnEnemy().Entity;
			actor.Replace<Component.Coordinates, Coordinates>(request.Get<CoordinatesRequest>().Value);
			actor.Is<Actor>(true);
		}
	}
}