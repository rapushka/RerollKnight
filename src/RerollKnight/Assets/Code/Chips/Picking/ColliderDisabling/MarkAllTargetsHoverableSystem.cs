using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class MarkTargetsHoverableOnInitializeSystem : SetHoverableAllTargetsSystemBase, IInitializeSystem
	{
		public MarkTargetsHoverableOnInitializeSystem(Contexts contexts) : base(contexts) { }
		protected override bool Value => true;

		public void Initialize() => Mark();
	}

	public class UnMarkTargetsHoverableOnTearDownSystem : SetHoverableAllTargetsSystemBase, ITearDownSystem
	{
		public UnMarkTargetsHoverableOnTearDownSystem(Contexts contexts) : base(contexts) { }
		protected override bool Value => false;

		public void TearDown() => Mark();
	}

	public abstract class SetHoverableAllTargetsSystemBase
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		protected SetHoverableAllTargetsSystemBase(Contexts contexts)
			=> _targets = contexts.GetGroup(Get<Target>());

		protected abstract bool Value { get; }

		protected void Mark()
		{
			foreach (var target in _targets)
				target.Is<Hoverable>(Value);
		}
	}
}