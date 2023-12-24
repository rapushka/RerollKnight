namespace Code
{
	public sealed class AbilitiesFeature : InjectableFeature
	{
		public AbilitiesFeature(SystemsFactory factory)
			: base(nameof(AbilitiesFeature), factory)
		{
			Add<CastSwapPositionsSystem>();
			Add<CastDealDamageSystem>();
			Add<CastSetNextSideSystem>();
			Add<CastShowNextSideSystem>();
			Add<CastPushSystem>();
			Add<CastRecoilSystem>();
		}
	}
}