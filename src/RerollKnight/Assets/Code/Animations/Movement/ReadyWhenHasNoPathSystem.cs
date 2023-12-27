using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ReadyWhenHasNoPathSystem : ReadyOnConditionSystemBase, IExecuteSystem
	{
		private readonly Contexts _contexts;

		protected ReadyWhenHasNoPathSystem(Contexts contexts) : base(contexts)
		{
			_contexts = contexts;
		}

		private Entity<GameScope> CurrentActor => Unique.GetEntity<CurrentActor>();
		private UniqueComponentsContainer<GameScope> Unique => _contexts.Get<GameScope>().Unique;

		public override void Initialize()
		{
			base.Initialize();

			ReadinessEntity.Add<DebugName, string>("Ready When Has No Path");
			Execute();
		}

		public void Execute()
		{
			if (Ready)
				return;

			Ready = !CurrentActor.Has<Path>() && !CurrentActor.Has<DestinationPosition>();
			CurrentActor.RemoveSafety<Component.Coordinates>();
		}
	}
}