using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	public class UnityTimeService : ITimeService
	{
		public float DeltaTime => Time.deltaTime;
		public float FixedDeltaTime => Time.fixedDeltaTime;
	}
}
