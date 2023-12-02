using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class SpawnActorOnRequestSystem : FulfillRequestSystemBase<SpawnActor>
	{
		private readonly ActorsFactory _actorsFactory;

		public SpawnActorOnRequestSystem(Contexts contexts, ActorsFactory actorsFactory)
			: base(contexts)
			=> _actorsFactory = actorsFactory;

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<CoordinatesRequest>());

			_actorsFactory.CreatePlayer(request.Get<CoordinatesRequest>().Value);

			request.Destroy();
		}
	}
}