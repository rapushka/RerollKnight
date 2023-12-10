using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class PutPlayerFirstSystem : IInitializeSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _players;

		public PutPlayerFirstSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_turnsQueue = turnsQueue;
			_players = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Player>());
		}

		public void Initialize()
		{
			foreach (var player in _players)
			{
				_turnsQueue.PutFirst(player);
				// _turnsQueue.Next();
				// player.Is<CurrentActor>(true);
			}
		}
	}
}