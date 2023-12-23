using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class ApplyChangeHealthSystem : FulfillRequestSystemBase<ChangeHealth>
	{
		public ApplyChangeHealthSystem(Contexts contexts) : base(contexts) { }

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<ForeignID>());

			var value = request.Get<ChangeHealth>().Value;
			var target = ID.Index.GetEntity(request.Get<ForeignID>().Value);

			if (target.Has<Health>())
				target.Replace<Health, int>(target.Get<Health, int>() + value);

			request.Destroy();
		}
	}
}