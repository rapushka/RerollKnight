namespace Code.Unity.Services.Interfaces
{
	public interface ITimeService : IService
	{
		float DeltaTime { get; }
	}
}
