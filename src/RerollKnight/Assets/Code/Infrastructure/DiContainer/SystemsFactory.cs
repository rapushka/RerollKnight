using Entitas;
using Zenject;

namespace Code
{
	/// <summary> Container.Rebind this in each zenject.context, with new dependencies for systems </summary>
	public class SystemsFactory
	{
		private readonly DiContainer _diContainer;

		[Inject] public SystemsFactory(DiContainer diContainer) => _diContainer = diContainer;

		public TSystem Create<TSystem>()
			where TSystem : ISystem
			=> _diContainer.Instantiate<TSystem>();

		public TSystem Create<TSystem>(StateMachineBase stateMachine)
			where TSystem : ISystem, IStateTransferSystem
		{
			var system = Create<TSystem>();
			system.StateMachine = stateMachine;
			return system;
		}
	}
}