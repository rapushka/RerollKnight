using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class HealingSystem : FulfillRequestSystemBase<ChangeHealth>
	{
		public HealingSystem(Contexts contexts) : base(contexts) { }

		protected override void OnRequest(Entity<RequestScope> request)
		{
			Debug.Assert(request.Has<AttachedTo>());

			var value = request.Get<ChangeHealth>().Value;
			if (value <= 0)
				return;

			var target = ID.Index.GetEntity(request.Get<AttachedTo>().Value);
			var newHealth = target.Get<Health, int>() + value;
			var health = target.Has<MaxHealth>() ? newHealth.Clamp(max: target.Get<MaxHealth>().Value) : newHealth;

			target.Replace<Health, int>(health);

			request.Destroy();
		}
	}
}