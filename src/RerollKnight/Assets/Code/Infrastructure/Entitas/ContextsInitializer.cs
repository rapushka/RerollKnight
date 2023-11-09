using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ContextsInitializer
	{
		private readonly Contexts _contexts;

		[Inject]
		public ContextsInitializer(Contexts contexts)
		{
			_contexts = contexts;

			InitializeScopes();

			CoordinatesComponent.Index.Initialize();
			CoordinatesUnderField.Index.Initialize();
		}

		private void InitializeScopes()
		{
			_contexts.InitializeScope<GameScope>();
			_contexts.InitializeScope<InputScope>();
			_contexts.InitializeScope<PlayerScope>();
			_contexts.InitializeScope<RequestScope>();
			_contexts.InitializeScope<ChipsScope>();
		}
	}
}