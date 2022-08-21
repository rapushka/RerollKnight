using System;
using Entitas;

namespace Code.Ecs.Systems.Services
{
	public sealed class RegisterServiceSystem<TService> : IInitializeSystem
	{
		private readonly TService _service;
		private readonly Action<TService> _initializeService;

		public RegisterServiceSystem(TService service, Action<TService> initializeService)
		{
			_service = service;
			_initializeService = initializeService;
		}

		public void Initialize() => _initializeService.Invoke(_service);
	}
}
