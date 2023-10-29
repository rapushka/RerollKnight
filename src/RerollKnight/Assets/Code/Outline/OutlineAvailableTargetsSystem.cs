using Entitas;
using Zenject;

namespace Code
{
	public sealed class OutlineAvailableTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;

		[Inject]
		public OutlineAvailableTargetsSystem(Contexts contexts)
			=> _targets = contexts.game.GetGroup(GameMatcher.Target);

		public void Execute()
		{
			foreach (var e in _targets)
			{
				e.EnableOutline = e.isAvailableToPick;
				e.ReplaceTargetState(TargetState.Available);
			}
		}
	}
}