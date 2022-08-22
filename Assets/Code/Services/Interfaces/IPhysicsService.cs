using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface IPhysicsService
	{
		bool Collided(Vector3 position, float radius, string excludedLayerName);
		int Overlap(Vector3 position, float radius, string excludedLayerName);
	}
}