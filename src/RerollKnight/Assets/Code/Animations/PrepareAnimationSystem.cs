using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class PrepareAnimationSystem : ReadyOnConditionSystemBase, IExecuteSystem
	{
		private readonly Contexts _contexts;

		protected PrepareAnimationSystem(Contexts contexts)
			: base(contexts)
			=> _contexts = contexts;

		private Entity<GameScope> CurrentActor => Unique.GetEntity<CurrentActor>();

		private UniqueComponentsContainer<GameScope> Unique => _contexts.Get<GameScope>().Unique;

		public void Execute()
		{
			Ready = !CurrentActor.Has<PlayAnimation>() || CurrentActor.Is<AnimationPrepared>();
		}
	}
}