using Entitas;

namespace Code
{
	public sealed class InitializeGameEntityBehavioursSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly GameEntityBehaviour[] _behaviours;

		public InitializeGameEntityBehavioursSystem(Contexts contexts, GameEntityBehaviour[] behaviours)
			=> (_contexts, _behaviours) = (contexts, behaviours);

		public void Initialize()
		{
			foreach (var behaviour in _behaviours)
			{
				behaviour.Initialize(_contexts);
			}
		}
	}
}