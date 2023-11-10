using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.RequestScope>;

namespace Code
{
	public sealed class SpawnPlayerSystem : ReactiveSystem<Entity<RequestScope>>
	{
		private readonly ServicesMediator _servicesMediator;

		[Inject]
		public SpawnPlayerSystem(Contexts contexts, ServicesMediator servicesMediator)
			: base(contexts.Get<RequestScope>())
			=> _servicesMediator = servicesMediator;

		protected override ICollector<Entity<RequestScope>> GetTrigger(IContext<Entity<RequestScope>> context)
			=> context.CreateCollector(AllOf(Get<SpawnPlayer>(), Get<CoordinatesRequest>()));

		protected override bool Filter(Entity<RequestScope> entity) => true;

		protected override void Execute(List<Entity<RequestScope>> entites)
		{
			foreach (var e in entites)
			{
				var player = _servicesMediator.SpawnPlayer().Entity;
				player.Replace<Component.Coordinates, Coordinates>(e.Get<CoordinatesRequest>().Value);
			}
		}
	}
}