using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastPushSystem : CastAbilitySystemBase<PushDistance>
	{
		private readonly PushCommand _push;

		public CastPushSystem(Contexts contexts, PushCommand push)
			: base(contexts)
			=> _push = push;

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var targetCoordinates = target.GetCoordinates();
			var casterCoordinates = CurrentActor.GetCoordinates();

			var direction = (targetCoordinates - casterCoordinates).Normalize();
			var distance = ability.Get<PushDistance>().Value;

			_push.Do(ability, target, distance, direction);
		}
	}
}