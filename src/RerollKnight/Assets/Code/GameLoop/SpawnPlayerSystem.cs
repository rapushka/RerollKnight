using System.Collections.Generic;
using Entitas;
using static RequestMatcher;

namespace Code
{
	public sealed class SpawnPlayerSystem : ReactiveSystem<RequestEntity>
	{
		public SpawnPlayerSystem(Contexts contexts) : base(contexts.request) { }

		protected override ICollector<RequestEntity> GetTrigger(IContext<RequestEntity> context)
			=> context.CreateCollector(AllOf(SpawnPlayer, CoordinatesRequest));

		protected override bool Filter(RequestEntity entity) => true;

		protected override void Execute(List<RequestEntity> entites)
		{
			foreach (var e in entites)
			{
				var playerBehaviour = ServicesMediator.SpawnPlayer();
				playerBehaviour.Entity.ReplaceCoordinates(e.coordinatesRequest.Value);
			}
		}
	}
}