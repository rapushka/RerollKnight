using System;
using Code.Unity.Services.Interfaces;

namespace Code.Unity.Services
{
	[Serializable]
	public class ServicesCollection
	{
		public IBalanceService Balance;
		public ITimeService Time;
		public IResourcesService Resources;
		public IViewsService Views;
	}
}
