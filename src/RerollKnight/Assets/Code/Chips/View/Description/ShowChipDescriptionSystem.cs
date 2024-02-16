using System.Collections.Generic;
using Code.Component;
using DG.Tweening;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ShowChipDescriptionSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly UiMediator _uiMediator;
		private readonly IViewConfig _viewConfig;

		private Sequence _sequence;

		public ShowChipDescriptionSystem(Contexts contexts, UiMediator uiMediator, IViewConfig viewConfig)
			: base(contexts.Get<GameScope>())
		{
			_uiMediator = uiMediator;
			_viewConfig = viewConfig;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Chip>(), Get<Hovered>()).AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			_sequence?.Kill();

			foreach (var e in entities)
			{
				if (e.Is<Hovered>())
					ShowWindow(e);
				else
					_uiMediator.HideWindow<ChipDescriptionWindow>();
			}
		}

		private void ShowWindow(Entity<GameScope> chip)
		{
			_sequence = DOTween.Sequence()
			                   .AppendInterval(_viewConfig.Chips.ShowDescriptionDelay)
			                   .AppendCallback(Show)
				;
			return;
			void Show() => _uiMediator.ShowAndGetWindow<ChipDescriptionWindow>().SetData(chip);
		}
	}
}