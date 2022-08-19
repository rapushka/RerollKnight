using Code.Unity.Services.Interfaces;
using UnityEngine;

namespace Code.Unity.Services.Realizations
{
	public class UnityTimeService : ITimeService
	{
		public float DeltaTime => Time.deltaTime;
	}
}
