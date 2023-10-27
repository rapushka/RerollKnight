using Entitas;
using Zenject;

namespace Code
{
	public class SystemsFactory
	{
		[Inject] private readonly DiContainer _diContainer;

		public TSystem Create<TSystem>()
			where TSystem : ISystem
			=> _diContainer.Instantiate<TSystem>();
	}
}