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
			Create.Initialize(@this);
		}

		public static T Mock<T>(this DiContainer @this)
			where T : class
		{
			var target = Substitute.For<T>();
			@this.BindInstance(target);
			return target;
		}

		public static Transform MockCellsHolder(this DiContainer @this, GameObject gameObject = null)
		{
			gameObject ??= new GameObject(NameOf.CellsHolder);
			@this.Mock<IHoldersProvider>().CellsHolder.Returns(gameObject.transform);
			return gameObject.transform;
		}

		public static Transform MockChipsHolder(this DiContainer @this, GameObject gameObject = null)
		{
			gameObject ??= new GameObject(NameOf.ChipsHolder);
			@this.Mock<IHoldersProvider>().ChipsHolder.Returns(gameObject.transform);
			return gameObject.transform;
		}

		public static void BindViewConfig(this DiContainer @this)
			=> @this.Bind<IViewConfig>().To<ViewConfig>().FromResources(ResourcePath.ViewConfig).AsSingle();

		public static void BindChipsFactory(this DiContainer @this)
		{
			@this.Bind<ChipsFactory>().AsSingle();
			@this.Mock<IAbilitiesFactory>();
			@this.Mock<IChipDescriptionBuilder>();
		}
	}
}