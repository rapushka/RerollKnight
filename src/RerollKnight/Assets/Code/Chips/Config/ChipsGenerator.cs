using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Zenject;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class ChipsGenerator
	{
		private readonly ChipsFactory _chipsFactory;
		private readonly ChipsConfig _chipsConfig;
		private readonly Dictionary<int, ChipsSet> _chipsSets;

		[Inject]
		public ChipsGenerator(ChipsConfig chipsConfig, ChipsFactory chipsFactory)
		{
			_chipsFactory = chipsFactory;
			_chipsConfig = chipsConfig;

			_chipsSets = new Dictionary<int, ChipsSet>();
		}

		public void CreateChipsFor(GameEntity dice)
		{
			var sides = dice.GetDependants().Where((e) => e.Has<Face>())
			                .OrderBy((e) => e.Get<Face>().Value)
			                .ToArray();

			var sideCount = sides.Length;

			if (!_chipsSets.ContainsKey(sideCount))
				_chipsSets[sideCount] = ChipsSet.FillForActor(sideCount, dice.Is<Enemy>(), _chipsConfig);

			var chipsSet = _chipsSets[sideCount];

			for (var i = 0; i < chipsSet.ChipsForFaces.Count; i++)
			{
				var side = sides[i];
				var chipsForFace = chipsSet.ChipsForFaces[i];

				foreach (var chipConfig in chipsForFace)
					_chipsFactory.Create(chipConfig, dice, side);
			}
		}
	}
}