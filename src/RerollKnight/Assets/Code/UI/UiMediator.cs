using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class UiMediator
	{
		private Contexts _contexts;

		[Inject]
		public void Construct(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void EndTurn() => _contexts.Get<RequestScope>().CreateEntity().Add<EndTurn>();
	}
}