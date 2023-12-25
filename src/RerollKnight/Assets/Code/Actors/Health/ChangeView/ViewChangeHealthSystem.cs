using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class ViewChangeHealthSystem : FulfillRequestSystemBase<ChangeHealth>
	{
		private readonly HealthChangeViewFactory _factory;

		public ViewChangeHealthSystem(Contexts contexts, HealthChangeViewFactory factory)
			: base(contexts)
			=> _factory = factory;

		protected override void OnRequest(Entity<RequestScope> request)
		{
			var value = request.Get<ChangeHealth>().Value;
			var target = request.GetTarget<GameScope>();

			_factory.Create(value, target);
		}
	}
}