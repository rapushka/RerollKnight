using System.Linq;
using Entitas;

namespace Code
{
	public class PickRandomOurChip : IInitializeSystem
	{
		private readonly Query _query;

		public PickRandomOurChip(Query query)
			=> _query = query;

		public void Initialize()
		{
			if (_query.ChipsOfCurrentActor.Any())
				_query.ChipsOfCurrentActor.PickRandom().Pick();
		}
	}
}