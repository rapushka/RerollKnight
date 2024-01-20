using NSubstitute;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	public static class BindExtensions
	{
		public static Transform BindCellsHolder(this DiContainer diContainer)
		{
			var cellsHolder = new GameObject("Cells Holder").transform;
			diContainer.BindHolderProvider().CellsHolder.Returns(cellsHolder);
			return cellsHolder;
		}

		public static IHoldersProvider BindHolderProvider(this DiContainer @this)
		{
			var holdersProvider = Substitute.For<IHoldersProvider>();
			@this.BindInstance(holdersProvider);
			return holdersProvider;
		}
	}
}