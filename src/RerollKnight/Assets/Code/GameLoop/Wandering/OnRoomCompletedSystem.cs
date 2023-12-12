﻿using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class OnRoomCompletedSystem : IExecuteSystem
	{
		private readonly GameplayStateMachine _stateMachine;
		private readonly IGroup<Entity<GameScope>> _enemies;
		private readonly IGroup<Entity<GameScope>> _players;
		private readonly IGroup<Entity<GameScope>> _doors;

		[Inject]
		public OnRoomCompletedSystem(Contexts contexts, GameplayStateMachine stateMachine)
		{
			_stateMachine = stateMachine;

			_enemies = contexts.GetGroup(AllOf(Get<Enemy>()).NoneOf(Get<Disabled>()));
			_players = contexts.GetGroup(Get<Player>());
			_doors = contexts.GetGroup(Get<DoorTo>());
		}

		public void Execute()
		{
			if (_stateMachine.CurrentState is LoadLevelGameplayState or InitializeGameplayState
			    || _doors.Any())
				return;

			if (!_enemies.Any())
				OnRoomCleared();

			if (!_players.Any())
				OnGameOver();
		}

		private void OnRoomCleared()
		{
			_stateMachine.ToState<WanderingGameplayState>();
		}

		private void OnGameOver()
			=> Debug.Log("TODO: Game Over");
	}
}