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

		public static GameEntity Player(int sideCount = 0) => Dice(sideCount).Is<Player>(true);
		public static GameEntity Enemy(int sideCount = 0)  => Dice(sideCount).Is<Enemy>(true);

		public static GameEntity Dice(int sideCount = 0)
		{
			var e = Entity().Add<Actor>();

			for (var i = 0; i < sideCount; i++)
				Side(e, i + 1);

			return e;
		}

		public static GameEntity Side(GameEntity owner, int value = 1)
			=> Entity()
			   .Add<ForeignID, string>(owner.EnsureID())
			   .Add<Face, int>(value);

		public static GameEntity Entity() => Context.CreateEntity();

		public static GameEntity Chip
		(
			IChipConfig config = null,
			GameEntity player = null,
			GameEntity side = null,
			bool isVisible = false
		)
		{
			player ??= Entity();
			side ??= Entity();
			config ??= Mock.ChipConfig();

			var chipsFactory = Container.Resolve<ChipsFactory>();
			return chipsFactory.Create(config, player, side)
			                   .Is<Visible>(isVisible);
		}

		public static GameEntity Cell(int x, int y, Coordinates.Layer layer = Coordinates.Layer.Bellow)
		{
			var cellsFactory = Container.Resolve<CellsFactory>();
			return cellsFactory.Create(x, y, layer);
		}
	}
}