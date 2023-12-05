using Code.Component;
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
			InitializeIndexes();
			InitializeFormatters();
		}

		private void InitializeScopes()
		{
			_contexts.InitializeScope<GameScope>();
			_contexts.InitializeScope<InputScope>();
			_contexts.InitializeScope<PlayerScope>();
			_contexts.InitializeScope<RequestScope>();
			_contexts.InitializeScope<ChipsScope>();
			_contexts.InitializeScope<InfrastructureScope>();
		}

		private void InitializeIndexes()
		{
			Component.Coordinates.Index.Initialize();
			CoordinatesUnderField.Index.Initialize();
			ID.Index.Initialize();
			ForeignID.GetIndex<GameScope>().Initialize();
			ForeignID.GetIndex<ChipsScope>().Initialize();
		}

		private void InitializeFormatters()
		{
			Entity<GameScope>.Formatter = new GameEntityFormatter();
			Entity<ChipsScope>.Formatter = new ChipsEntityFormatter();
		}
	}
}