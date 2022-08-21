using Code.Unity.Views;
using Entitas;
using UnityEngine;

namespace Code.Unity.Services.Interfaces
{
	public interface IViewsService : IService
	{
		GameObject BindViewToEntity(GameObject viewPrefab, IEntity entity);
	}
}
