using Entitas;

namespace Code
{
	public sealed class InitializeGameEntityBehavioursSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly GameEntityBehaviourOld[] _behaviours;

		public InitializeGameEntityBehavioursSystem(Contexts contexts, GameEntityBehaviourOld[] behaviours)
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