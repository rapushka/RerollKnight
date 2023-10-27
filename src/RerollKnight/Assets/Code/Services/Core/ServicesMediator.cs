namespace Code
{
	public static class ServicesMediator
	{
		private static ServicesContext Context => Contexts.sharedInstance.services;

		public static IResourcesService Resources => Context.resources.Value;

		public static IAssetsService Assets => Context.assets.Value;

		public static ILayoutService Layout => Context.layout.Value;

		public static IEntitiesManipulatorService EntitiesManipulator => Context.entitiesManipulator.Value;

		public static GameStateMachine GameStateMachine => Context.gameStateMachine.Value.StateMachine;

		public static GameEntityBehaviour SpawnPlayer() => Assets.SpawnBehaviour(Resources.PlayerPrefab);
	}
}