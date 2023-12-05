using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class IdentifyAllEntitiesSystem<TScope> : IExecuteSystem
		where TScope : IScope
	{
		private readonly Contexts _contexts;

		public IdentifyAllEntitiesSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Execute()
		{
			foreach (var entity in _contexts.Get<TScope>().GetEntities())
			{
				if (!entity.Has<ID>())
					entity.Identify();
			}
		}
	}

	public class CounterServices
	{
		private static CounterServices _instance;
		public static CounterServices Instance => _instance ??= new CounterServices();

		private int _current;

		public int Next => _current++;

		private CounterServices() { }
	}
}