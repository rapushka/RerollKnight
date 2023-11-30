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

		protected void Add<TSystem, TValue>(TValue value)
			where TSystem : ISystem, IDataReceiver<TValue>
		{
			var system = _factory.Create<TSystem>();
			system.SetData(value);
			Add(system);
		}
	}
}