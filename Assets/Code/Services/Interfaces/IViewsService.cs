using Entitas;
using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface IViewsService
	{
		GameObject LoadViewForEntity(string viewPath, IEntity entity);
		GameObject LoadViewForEntity(GameObject viewPrefab, IEntity entity);
	}
}