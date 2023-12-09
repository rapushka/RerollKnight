using Entitas;
using Zenject;

namespace Code
{
	public abstract class InjectableFeature : Feature
	{
		protected readonly SystemsFactory Factory;

		[Inject]
		protected InjectableFeature(string name, SystemsFactory factory)
			: base(name)
			=> Factory = factory;

		protected TSystem Add<TSystem>() where TSystem : ISystem
		{
			var system = Factory.Create<TSystem>();
			Add(system);
			return system;
		}
	}
}