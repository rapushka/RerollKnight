using Code.Component;
using Entitas.Generic;
using Zenject;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code.Editor.Tests
{
	public static class Create
	{
		private static DiContainer Container { get; set; }

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		public static void Initialize(DiContainer container)
		{
			Container = container;
		}

		public static GameEntity Player() => Entity().Is<Player>(true);

		public static GameEntity Entity() => Context.CreateEntity();

		public static GameEntity Chip(IChipConfig config = null, GameEntity player = null, GameEntity side = null)
		{
			player ??= Player();
			side ??= Entity();
			config ??= Mock.ChipConfig();

			var chipsFactory = Container.Resolve<ChipsFactory>();
			return chipsFactory.Create(config, player, side);
		}

		public static GameEntity Cell(int x, int y, Coordinates.Layer layer = Coordinates.Layer.Bellow)
		{
			var cellsFactory = Container.Resolve<CellsFactory>();
			return cellsFactory.Create(x, y, layer);
		}
	}
}