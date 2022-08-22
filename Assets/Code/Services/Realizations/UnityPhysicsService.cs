using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	public class UnityPhysicsService : IPhysicsService
	{
		private readonly Collider[] _colliders;

		public UnityPhysicsService()
		{
			_colliders = new Collider[1];
		}

		public bool Collided(Vector3 position, float radius, string excludedLayerName) 
			=> Overlap(position, radius, excludedLayerName) > 0;

		public int Overlap(Vector3 position, float radius, string excludedLayerName) 
			=> Physics.OverlapSphereNonAlloc(position, radius, _colliders, ~LayerMask.GetMask(excludedLayerName));
	}
}