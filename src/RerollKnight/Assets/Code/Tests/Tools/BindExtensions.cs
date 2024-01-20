using NSubstitute;
using UnityEngine;
using Zenject;
using static Code.Editor.Tests.Constants;

namespace Code.Editor.Tests
{
	public static class BindExtensions
	{
		public static Transform BindCellsHolder(this DiContainer diContainer)
		{
			var cellsHolder = new GameObject(NameOf.CellsHolder).transform;
			diContainer.BindHolderProvider().CellsHolder.Returns(cellsHolder);
			return cellsHolder;
		}

		public static IHoldersProvider BindHolderProvider(this DiContainer @this)
		{
			var holdersProvider = Substitute.For<IHoldersProvider>();
			@this.BindInstance(holdersProvider);
			return holdersProvider;
		}

		public static void BindViewConfig(this DiContainer diContainer)
		{
			diContainer.Bind<IViewConfig>().To<ViewConfig>().FromResources(ResourcePath.ViewConfig).AsSingle();
		}
	}
}