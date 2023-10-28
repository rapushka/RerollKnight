using Zenject;

namespace Code
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		private GameFeature _feature;

		[Inject] public void Construct(GameFeature feature) => _feature = feature;

		protected override Feature Feature => _feature;
	}
}