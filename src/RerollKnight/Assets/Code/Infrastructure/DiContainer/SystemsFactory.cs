using Entitas;
using Zenject;

namespace Code
{
	/// <summary> Container.Rebind it in each context, with new dependencies for systems </summary>
	public class SystemsFactory
	{
		[Inject] private readonly DiContainer _diContainer;

		public TSystem Create<TSystem>()
			where TSystem : ISystem
			=> _diContainer.Instantiate<TSystem>();
	}
}