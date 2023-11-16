using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class SpawnEnemySystem : FulfillRequestSystemBase<SpawnEnemy>
	{
		private readonly ServicesMediator _servicesMediator;

		public SpawnEnemySystem(Contexts contexts, ServicesMediator servicesMediator)
			: base(contexts)
		{
			_servicesMediator = servicesMediator;
		}

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<CoordinatesRequest>());

			var enemy = _servicesMediator.SpawnEnemy().Entity;
			enemy.Replace<Component.Coordinates, Coordinates>(request.Get<CoordinatesRequest>().Value);
			enemy.Is<Enemy>(true);
		}
	}
}