using System.Collections.Generic;
using Code.Services.Interfaces;
using Code.Workflow;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.ControlsSystems.Jumping
{
	public sealed class GroundCheckSystem : ReactiveSystem<InputEntity>
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _jumpers;

		public GroundCheckSystem(Contexts contexts)
			: base(contexts.input)
		{
			_contexts = contexts;
			_jumpers = contexts.game.GetAllOf
			(
				GameMatcher.InputReceiver,
				GameMatcher.LegsPointTransform
			);
		}

		private IPhysicsService Physics => _contexts.services.physicsService.Value;
		private IBalanceService BalanceService => _contexts.services.balanceService.Value;

		protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
			=> context.CreateCollector(InputMatcher.JumpReceive.Added());

		protected override bool Filter(InputEntity entity) => true;

		protected override void Execute(List<InputEntity> entites)
		{
			const string excludedLayerName = Constants.LayerName.Creature;
			foreach (GameEntity e in _jumpers.GetEntities())
			{
				Vector3 overlapPosition = e.legsPointTransform.Value.position;
				float radius = BalanceService.Player.GroundCheckerRadius;

				e.performJump = Physics.Collided(overlapPosition, radius, excludedLayerName);
			}
		}
	}
}