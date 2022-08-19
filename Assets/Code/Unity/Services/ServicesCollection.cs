using System;

namespace Code.Unity.Services
{
	[Serializable]
	public class ServicesCollection
	{
		public BalanceService Balance;
		public TimeService Time;
	}
}
