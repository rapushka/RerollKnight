namespace Code
{
	public sealed class HealthFeature : InjectableFeature
	{
		public HealthFeature(SystemsFactory factory)
			: base(nameof(HealthFeature), factory)
		{
			Add<ApplyChangeHealthSystem>();
			Add<DestroyEntityWithZeroHpSystem>();
			Add<ClampMaxHealSystem>();

			Add<CascadeDestroySystem<GameScope>>();
			Add<CascadeDestroySystem<ChipsScope>>();
			Add<CascadeDestroySystem<RequestScope>>();
			Add<EndTurnOnCurrentActorDeathSystem>();
		}
	}
}