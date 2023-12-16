using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ResetContext<TScope> : ITearDownSystem
		where TScope : IScope
	{
		private readonly Contexts _contexts;

		[Inject]
		public ResetContext(Contexts contexts)
			=> _contexts = contexts;

		public void TearDown() => _contexts.Get<TScope>().Reset();
	}
}