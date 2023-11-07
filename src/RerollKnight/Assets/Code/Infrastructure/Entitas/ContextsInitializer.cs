using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ContextsInitializer : IInitializable
	{
		private readonly Contexts _contexts;

		[Inject]
		public ContextsInitializer(Contexts contexts)
		{
			_contexts = contexts;
		}

		void IInitializable.Initialize()
		{
			_contexts.InitializeScope<GameScope>();
			_contexts.InitializeScope<InputScope>();
			_contexts.InitializeScope<PlayerScope>();
			_contexts.InitializeScope<RequestScope>();
			_contexts.InitializeScope<ChipsScope>();
		}
	}
}