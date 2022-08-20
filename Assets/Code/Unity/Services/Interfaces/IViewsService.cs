using Code.Unity.Views;

namespace Code.Unity.Services.Interfaces
{
	public interface IViewsService : IService
	{
		PositionView PlayerPosition { get; }
	}
}
