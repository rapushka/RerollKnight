using Entitas;
using Zenject;
using static Code.OutlineParams;

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
				e.ReplaceOutline(new OutlineParams(Type.Available, e.isAvailableToPick));
		}
	}
}