using Entitas;
using UnityEngine;
using Zenject;
using static RequestMatcher;

namespace Code
{
	public sealed class SetAllAvailabilitySystem : FulfillRequestSystemBase
	{
		private readonly IGroup<GameEntity> _targets;

		[Inject]
		public SetAllAvailabilitySystem(Contexts contexts) : base(contexts)
			=> _targets = contexts.game.GetGroup(GameMatcher.Target);

		protected override IMatcher<RequestEntity> Request => SetAllTargetsAvailability;

		protected override void OnRequest(RequestEntity request)
		{
			Debug.Log($"request.setAllTargetsAvailability.Value = {request.setAllTargetsAvailability.Value}");

			foreach (var e in _targets)
				e.isAvailableToPick = request.setAllTargetsAvailability.Value;
		}
	}
}