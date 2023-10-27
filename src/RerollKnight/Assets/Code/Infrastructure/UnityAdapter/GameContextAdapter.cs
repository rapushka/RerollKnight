using Zenject;

namespace Code
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		[Inject] private readonly GameFeature _feature;

		protected override Feature Feature => _feature;
	}
}