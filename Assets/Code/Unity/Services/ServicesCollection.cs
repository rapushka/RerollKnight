using System;
using Code.Unity.Services.Interfaces;
using Code.Unity.Services.Realizations;

namespace Code.Unity.Services
{
	[Serializable]
	public class ServicesCollection
	{
		public SerializableBalanceService Balance;
		public ITimeService Time;
	}
}
