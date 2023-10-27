using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class UnpickChipOnRequestSystem : ReactiveSystem<RequestEntity>
	{
		private readonly Contexts _contexts;

		public UnpickChipOnRequestSystem(Contexts contexts) : base(contexts.request) => _contexts = contexts;

		protected override ICollector<RequestEntity> GetTrigger(IContext<RequestEntity> context)
			=> context.CreateCollector(RequestMatcher.UnpickAllTargets);

		protected override bool Filter(RequestEntity entity) => entity.isUnpickAllTargets;

		protected override void Execute(List<RequestEntity> entites)
		{
			if (_contexts.game.isPickedChip)
				_contexts.game.pickedChipEntity.Unpick();
		}
	}
}