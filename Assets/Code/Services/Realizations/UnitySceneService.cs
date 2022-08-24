using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	public class UnitySceneService : ISceneService
	{
		private readonly Camera _camera;
		private readonly RaycastHit[] _hits;

		public UnitySceneService()
		{
			_camera = Camera.main;
			_hits = new RaycastHit[1];
		}

		public Vector3 ScreenToWorldPoint(Vector2 position)
		{
			Ray ray = _camera.ScreenPointToRay(position);
			Physics.RaycastNonAlloc(ray, _hits);
			
			return _hits[0].point;
		}
	}
}