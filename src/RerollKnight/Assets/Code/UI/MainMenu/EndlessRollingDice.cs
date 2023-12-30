using UnityEngine;

namespace Code
{
	public class EndlessRollingDice : MonoBehaviour
	{
		[SerializeField] private float _rotationSpeed = 750f;
		[SerializeField] private float _directionRandomizeSmooth = 0.1f;

		private Vector3 _randomDirection;

		private void Start()
		{
			_randomDirection = Random.insideUnitSphere;
		}

		private void Update()
		{
			_randomDirection += Random.insideUnitSphere * _directionRandomizeSmooth;
			transform.Rotate(_randomDirection, _rotationSpeed * Time.deltaTime);
		}
	}
}