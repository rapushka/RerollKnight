using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class CellsParenthood : EntitiesDebugParenthood<GameScope>
	{
#if DEBUG
		private const string RootNameSuffix = "_Cells Root";

		private GameObject _cellsRoot;
		private RangeInt? _indexesRange;

		protected override void OnStart()
		{
			_cellsRoot = new GameObject(RootNameSuffix) { transform = { parent = ContextBehaviour.transform } };
		}

		protected override void HandleEntity(Entity<GameScope> entity, Transform entityBehaviour)
		{
			if (!entity.Is<Cell>())
				return;

			UpdateHolderName(entity);
			entityBehaviour.SetParent(_cellsRoot.transform);
		}

		private void UpdateHolderName(Entity<GameScope> entity)
		{
			_indexesRange ??= new RangeInt(entity.creationIndex);

			_indexesRange = _indexesRange.Value.Recreate(entity.creationIndex);
			_cellsRoot.name = _indexesRange + RootNameSuffix;
		}
#endif
	}
}