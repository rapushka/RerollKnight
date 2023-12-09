using System.Collections.Generic;
using Entitas;

namespace Code
{
	public abstract class StateFeatureBase : InjectableFeature, IStateTransferSystem
	{
		private readonly List<IStateTransferSystem> _stateTransferSystems = new();

		protected StateFeatureBase(string name, SystemsFactory factory) : base(name, factory) { }

		public StateMachineBase StateMachine
		{
			set
			{
				foreach (var system in _stateTransferSystems)
					system.StateMachine = value;
			}
		}

		protected new TSystem Add<TSystem>() where TSystem : ISystem
		{
			var system = Factory.Create<TSystem>();
			if (system is IStateTransferSystem stateTransferSystem)
				_stateTransferSystems.Add(stateTransferSystem);

			Add(system);
			return system;
		}
	}
}