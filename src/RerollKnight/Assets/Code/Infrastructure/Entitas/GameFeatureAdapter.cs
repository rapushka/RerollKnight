using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class GameFeatureAdapter : FeatureAdapterBase
	{
		private GameFeature _feature;

		[Inject] public void Construct(GameFeature feature) => _feature = feature;

		protected override Systems CreateSystems() => _feature;
	}
}