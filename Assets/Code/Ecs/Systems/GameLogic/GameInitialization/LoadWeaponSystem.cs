using Entitas;

namespace Code.Ecs.Systems.GameLogic.GameInitialization
{
	public sealed class LoadWeaponSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public LoadWeaponSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			
		}
	}
}