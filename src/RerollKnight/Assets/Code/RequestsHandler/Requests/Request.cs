using System;
using Entitas.Generic;

namespace Code
{
	public abstract class Request
	{
		public abstract Action Action { get; }

		protected static Entity<RequestScope> NewEntity => Contexts.Instance.Get<RequestScope>().CreateEntity();
	}

	/// <summary>
	/// Do NOT inherit from it! <br/>
	/// Needed only to check if some Request is the ValueRequest lol
	/// </summary>
	public abstract class ValueRequest : Request
	{
		public object Value { get; set; }
	}

	public abstract class Request<T> : ValueRequest
	{
		public new T Value { get; set; }
	}
}