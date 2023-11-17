using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameplayFeatureAdapter : FeatureAdapterBase
	{
		private GameplayFeature _feature;

		[Inject] public void Construct(GameplayFeature feature) => _feature = feature;

		protected override Systems CreateSystems() => _feature;
	}
}