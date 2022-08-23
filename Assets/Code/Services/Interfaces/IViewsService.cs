using Entitas;

namespace Code.Services.Interfaces
{
	public interface IViewsService
	{
		void LoadViewForEntity(string viewPath, IEntity entity);
	}
}
