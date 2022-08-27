namespace Code.Services.Interfaces
{
	public interface ITimeService
	{
		float DeltaTime { get; }
		float FixedDeltaTime { get; }
	}
}
