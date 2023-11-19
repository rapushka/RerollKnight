using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class SpawnPlayerSystem : FulfillRequestSystemBase<SpawnPlayer>
	{
		private readonly ServicesMediator _servicesMediator;

		[Inject]
		public SpawnPlayerSystem(Contexts contexts, ServicesMediator servicesMediator)
			: base(contexts)
			=> _servicesMediator = servicesMediator;

		protected override void OnRequest(Entity<RequestScope> request)
		{
			var player = _servicesMediator.SpawnPlayer().Entity;
			player.Replace<Component.Coordinates, Coordinates>(request.Get<CoordinatesRequest>().Value);
		}
	}
}