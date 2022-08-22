using System;
using Code.Services.Interfaces;

namespace Code.Services
{
	[Serializable]
	public class ServicesCollection
	{
		public IBalanceService Balance;
		public ITimeService Time;
		public IResourcesService Resources;
		public IViewsService Views;
		public IInputService Input;
		public IPhysicsService Physics;
		public IIdentifierService<int> Identifier;
	}
}
