using Entitas;
using Zenject;

namespace Code
{
	public abstract class InjectableFeature : Feature
	{
		private readonly SystemsFactory _factory;

		[Inject]
		protected InjectableFeature(string name, SystemsFactory factory)
			: base(name)
			=> _factory = factory;

		protected void Add<TSystem>() where TSystem : ISystem => Add(_factory.Create<TSystem>());
	}
}