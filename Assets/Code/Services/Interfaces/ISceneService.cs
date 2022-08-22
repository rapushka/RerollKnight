using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface ISceneService
	{
		Vector2 ScreenToWorldPoint(Vector2 position);
	}
}