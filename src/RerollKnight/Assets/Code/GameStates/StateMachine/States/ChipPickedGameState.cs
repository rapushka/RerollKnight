namespace Code
{
	public class ChipPickedGameState : GameStateBase<ChipPickedGameState.StateFeature>
	{
		public ChipPickedGameState(StateFeature systems) : base(systems) { }

		// public override void Enter() => RequestEmitter.Instance.Send<MarkAllTargetsAvailableRequest>();

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base(nameof(StateFeature), factory)
			{
				// 
			}
		}
	}
}