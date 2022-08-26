using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.View
{
	public sealed class InputToRotationSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private GameEntity _player;

		public InputToRotationSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		
		private Quaternion TargetRotation => Quaternion.LookRotation(ReceivedDirection, Vector3.up);
		private bool IsMoved => ReceivedDirection != Vector3.zero;
		private Vector3 ReceivedDirection => _contexts.input.moveDirectionReceive.Value;

		public void Initialize()
		{
			_player = _contexts.game.playerEntity;
			_player.AddTargetRotation(TargetRotation);
		}

		public void Execute() => _player.Do(SetRotation, @if: IsMoved);

		private void SetRotation(GameEntity p) => p.targetRotation.Value = TargetRotation;
	}
}