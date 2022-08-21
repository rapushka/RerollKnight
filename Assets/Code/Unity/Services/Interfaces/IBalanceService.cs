namespace Code.Unity.Services.Interfaces
{
	public interface IBalanceService : IService
	{
		public float GravityScale { get; }
		public float PlayerSpeed { get; }
	}
}
