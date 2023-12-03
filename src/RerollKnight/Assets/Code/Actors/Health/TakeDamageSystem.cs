using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class TakeDamageSystem : FulfillRequestSystemBase<ChangeHealth>
	{
		public TakeDamageSystem(Contexts contexts) : base(contexts) { }

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<AttachedTo>());

			// idk how to deal with 0
			var value = request.Get<ChangeHealth>().Value;
			if (value > 0)
				return;

			var target = ID.Index.GetEntity(request.Get<AttachedTo>().Value);
			target.Replace<Health, int>(target.Get<Health, int>() + value);

			if (target.Get<Health>().Value <= 0)
			{
				Debug.Log($"{target} has been killed");
				target.Destroy(); // TODO: better destroy
			}

			request.Destroy();
		}
	}
}