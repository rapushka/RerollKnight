using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	/// <summary> Stores requests to send them all at the beginning of the frame </summary>
	public class RequestEmitter
	{
		private readonly List<Request> _requests = new();

		private static RequestEmitter _instance;

		private RequestEmitter() { }

		public static RequestEmitter Instance => _instance ??= new RequestEmitter();

		public void Send<TRequest>()
			where TRequest : Request, new()
		{
			var request = new TRequest();
			Debug.Assert(request is not ValueRequest, "Don't throw Value requests as usual!");

			_requests.Add(request);
		}

		public void Send<TRequest, TValue>(TValue value)
			where TRequest : Request<TValue>, new()
			=> _requests.Add(new TRequest { Value = value });

		public void EmitAll()
		{
			foreach (var request in _requests)
				request.Action.Invoke();

			_requests.Clear();
		}
	}
}