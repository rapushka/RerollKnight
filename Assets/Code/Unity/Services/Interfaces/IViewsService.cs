using Entitas;
using UnityEngine;

namespace Code.Unity.Services.Interfaces
{
	public interface IViewsService : IService
	{
		GameObject BindViewToEntity(string viewPath, IEntity entity);
	}
}
