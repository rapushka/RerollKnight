using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	/// <summary> Stores requests to send them all at the beginning of the frame </summary>
	public class RequestHandler
	{
		private readonly List<Request> _requests = new();

		private static RequestHandler _instance;

		private RequestHandler() { }

		public static RequestHandler Instance => _instance ??= new RequestHandler();

		public void Send<TRequest>()
			where TRequest : Request, new()
		{
			var request = new TRequest();
			Debug.Assert(request is ValueRequest, "Don't throw Value requests as usual!");

			_requests.Add(request);
		}

		public void Send<TRequest, TValue>(TValue value)
			where TRequest : Request<TValue>, new()
			=> _requests.Add(new TRequest { Value = value });

		public void InvokeAll()
		{
			foreach (var request in _requests)
				request.Action.Invoke();

			_requests.Clear();
		}
	}
}