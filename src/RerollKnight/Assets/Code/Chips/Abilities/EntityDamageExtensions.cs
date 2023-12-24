using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public static class EntityDamageExtensions
	{
		public static void TakeDamage(this Entity<GameScope> @this, int value)
		{
			Debug.Assert(value >= 0);

			@this.ChangeHealth(-value);
		}

		public static void Heal(this Entity<GameScope> @this, int value)
		{
			Debug.Assert(value >= 0);

			@this.ChangeHealth(value);
		}

		public static void ChangeHealth(this Entity<GameScope> @this, int value)
			=> Contexts.Instance.Get<RequestScope>().CreateEntity()
			           .Add<ChangeHealth, int>(value)
			           .Add<ForeignID, string>(@this.Get<ID>().Value);
	}
}