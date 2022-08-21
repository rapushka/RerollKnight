using Entitas;

namespace Code.Unity.Services.Interfaces
{
	public interface IViewsService : IService
	{
		void BindViewToEntity(string viewPath, IEntity entity);
	}
}
