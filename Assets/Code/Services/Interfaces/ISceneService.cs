using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface ISceneService
	{
		Vector3 ScreenToWorldPoint(Vector2 position);
	}
}