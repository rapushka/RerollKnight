using Entitas.Generic;
using NSubstitute;
using UnityEngine;
using Zenject;
using static Code.Editor.Tests.Constants;

namespace Code.Editor.Tests
{
	public static class BindExtensions
	{
		/// <summary> Common Binding, which is need for majority of the tests, that use injection </summary>
		public static void CommonBind(this DiContainer @this)
		{
			@this.Bind<Contexts>().FromInstance(Contexts.Instance).AsSingle();

			@this.Bind<IAssetsService>().To<AssetsService>().AsSingle();
			@this.Bind<IResourcesService>().To<ResourcesService>().AsSingle();
			@this.BindViewConfig();

			Contexts.Instance.Initialize();
		}

		public static Transform BindCellsHolder(this DiContainer @this)
		{
			var cellsHolder = new GameObject(NameOf.CellsHolder).transform;
			@this.BindHolderProvider().CellsHolder.Returns(cellsHolder);
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