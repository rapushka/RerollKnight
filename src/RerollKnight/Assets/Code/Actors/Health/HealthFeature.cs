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

			Add<DestroyWithDependentsSystem<GameScope>>();
			Add<DestroyWithDependentsSystem<ChipsScope>>();
			Add<DestroyWithDependentsSystem<RequestScope>>();
			Add<EndTurnOnCurrentActorDeathSystem>();
		}
	}
}