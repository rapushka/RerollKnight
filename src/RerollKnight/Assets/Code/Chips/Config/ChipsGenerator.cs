using System.Linq;
using Code.Component;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class ChipsGenerator
	{
		private readonly ChipsConfig _chipsConfig;
		private readonly ChipsFactory _chipsFactory;

		private ChipsSet _readyPlayerChips;
		private ChipsSet _readyEnemyChips;

		public ChipsGenerator(ChipsConfig chipsConfig, ChipsFactory chipsFactory)
		{
			_chipsConfig = chipsConfig;
			_chipsFactory = chipsFactory;
		}

		public void CreateChipsFor(GameEntity actor)
		{
			if (actor.Is<Player>())
				CreateChipsForActor(actor, ref _readyPlayerChips);

			if (actor.Is<Enemy>())
				CreateChipsForActor(actor, ref _readyEnemyChips);
		}

		private void CreateChipsForActor(GameEntity actor, ref ChipsSet chipsSet)
		{
			chipsSet ??= new ChipsSet(actor, _chipsConfig);
			var faces = actor.GetDependants().Where((e) => e.Has<Face>())
			                 .OrderBy((e) => e.Get<Face>().Value)
			                 .ToArray();

			for (var i = 0; i < chipsSet.ChipsForFaces.Count; i++)
			{
				var face = faces[i];
				var chipsForFace = chipsSet.ChipsForFaces[i];

				foreach (var chipConfig in chipsForFace)
					_chipsFactory.Create(chipConfig, actor, face);
			}
		}
	}
}