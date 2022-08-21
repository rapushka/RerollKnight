using Entitas;
using UnityEngine;

namespace Code.Unity.Services.Interfaces
{
	public interface IViewsService : IService
	{
		void LoadViewForEntity(string viewPath, IEntity entity);
	}
}
