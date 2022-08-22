using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	public class UnitySceneService : ISceneService
	{
		public Vector2 ScreenToWorldPoint(Vector2 position) 
			=> Camera.main.ScreenToWorldPoint(position);
	}
}