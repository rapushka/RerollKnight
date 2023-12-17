using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ShowChipDescriptionSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly UiMediator _uiMediator;

		public ShowChipDescriptionSystem(Contexts contexts, UiMediator uiMediator)
			: base(contexts.Get<GameScope>())
			=> _uiMediator = uiMediator;

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Chip>(), Get<Hovered>()).AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				if (e.Is<Hovered>())
					_uiMediator.ShowWindow<ChipDescriptionWindow>();
				else
					_uiMediator.HideWindow<ChipDescriptionWindow>();
			}
		}
	}
}