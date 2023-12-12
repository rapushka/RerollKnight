namespace Code
{
	public static class WaitAndThenToStateExtensions
	{
		public static void WaitAndThenToState<TState>(this StateMachineBase @this, float after)
		{
			var data = Code.WaitAndThenToState.To<TState>(after);
			@this.ToState<WaitAndThenToState, WaitAndThenToState.Data>(data);
		}
	}
}