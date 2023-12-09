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

		protected void Add<TSystem>() where TSystem : ISystem => Add(Factory.Create<TSystem>());

		protected void Add<TSystem, TValue>(TValue value)
			where TSystem : ISystem, IDataReceiver<TValue>
		{
			var system = Factory.Create<TSystem>();
			system.SetData(value);
			Add(system);
		}
	}
}