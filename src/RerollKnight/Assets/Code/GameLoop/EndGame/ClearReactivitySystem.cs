using Entitas;

namespace Code
{
	public class ClearReactivitySystem : ITearDownSystem
	{
		private readonly GameplayFeature _feature;

		public ClearReactivitySystem(GameplayFeature feature)
			=> _feature = feature;

		public void TearDown()
			=> _feature.DeactivateReactiveSystems();
	}
}