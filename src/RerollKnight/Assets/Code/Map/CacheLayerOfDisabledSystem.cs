using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class CacheLayerOfDisabledSystem : ReactiveSystem<Entity<GameScope>>
	{
		public CacheLayerOfDisabledSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<Disabled>().AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity) => entity.Has<Component.Coordinates>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				var coordinates = e.GetCoordinates();
				Coordinates newCoordinates;

				if (e.Is<Disabled>())
				{
					e.Replace<CashedLayer, Coordinates.Layer>(coordinates.OnLayer);
					newCoordinates = coordinates.WithLayer(Coordinates.Layer.None);
				}
				else
				{
					newCoordinates = coordinates.WithLayer(e.Get<CashedLayer>().Value);
					// e.Replace<Component.Coordinates, Coordinates>(coordinates.WithLayer(e.Get<CashedLayer>().Value));
					e.RemoveSafety<CashedLayer>();
				}

				if (!e.Get<Component.Coordinates>().Value.Equals(newCoordinates))
					e.Replace<Component.Coordinates, Coordinates>(newCoordinates);
			}
		}
	}
}