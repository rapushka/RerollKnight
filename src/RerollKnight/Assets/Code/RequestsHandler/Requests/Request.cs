using System;

namespace Code
{
	public abstract class Request
	{
		public abstract Action Action { get; }

		protected static RequestEntity NewEntity => Contexts.sharedInstance.request.CreateEntity();
	}

	public abstract class ValueRequest : Request
	{
		public object Value { get; set; }
	}

	public abstract class Request<T> : ValueRequest
	{
		public new T Value { get; set; }
	}
}