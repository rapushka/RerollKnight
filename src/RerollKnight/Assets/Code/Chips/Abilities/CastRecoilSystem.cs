using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class CastRecoilSystem : CastAbilitySystemBase<Recoil>
	{
		private readonly PushCommand _push;

		public CastRecoilSystem(Contexts contexts, PushCommand push)
			: base(contexts)
			=> _push = push;

		protected override void Cast(Entity<ChipsScope> ability, Entity<GameScope> target)
		{
			var targetCoordinates = target.GetCoordinates();
			var casterCoordinates = CurrentActor.GetCoordinates();

			var direction = (casterCoordinates - targetCoordinates).Normalize();
			var distance = ability.Get<Recoil>().Value;

			_push.Do(ability, CurrentActor, distance, direction);
		}
	}
}