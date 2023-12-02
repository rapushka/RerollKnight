using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class CellsParenthood : EntitiesDebugParenthood<GameScope>
	{
#if DEBUG
		private GameObject _cellsRoot;

		protected override void HandleEntity(Entity<GameScope> entity, Transform entityBehaviour)
		{
			if (entity.Is<Cell>())
				entityBehaviour.SetParent(_cellsRoot.transform);
		}

		protected override void OnStart()
		{
			_cellsRoot = new GameObject("_Cells Root") { transform = { parent = ContextBehaviour.transform } };
		}
#endif
	}
}