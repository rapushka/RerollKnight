using Entitas;

namespace Code.Unity.Services.Interfaces
{
	public interface IViewsService : IService
	{
		void LoadViewForEntity(string viewPath, IEntity entity);
	}
}
