using Code.Component;
using Entitas;
using Entitas.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class ChipDescriptionWindow : WindowBase
	{
		[SerializeField] private TMP_Text _descriptionTextMesh;

		private IGroup<Entity<GameScope>> _hoveredChips;
		private Contexts _contexts;

		[Inject]
		public void Construct(Contexts contexts)
			=> _contexts = contexts;

		public override void Initialize()
			=> _hoveredChips = _contexts.GetGroup(AllOf(Get<Chip>(), Get<Hovered>()));

		private Entity<GameScope> HoveredChip => _hoveredChips.GetSingleEntity();

		protected override void OnOpen()
		{
			base.OnOpen();

			var hoveredChip = HoveredChip;
			_descriptionTextMesh.text = hoveredChip.Get<Description>().Value;
		}
	}
}