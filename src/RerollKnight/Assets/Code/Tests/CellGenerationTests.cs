using Entitas.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class CellGenerationTests
	{
		private DiContainer _diContainer;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		[SetUp]
		public void SetUp()
		{
			_diContainer = new DiContainer();
			_diContainer.Bind<CellsFactory>().AsSingle();

			_diContainer.Bind<IAssetsService>().To<AssetsService>().AsSingle();
			_diContainer.Bind<IResourcesService>().To<ResourcesService>().AsSingle();

			var holdersProvider = Substitute.For<IHoldersProvider>();
			holdersProvider.CellsHolder.Returns(new GameObject("Cells Holder").transform);
			_diContainer.BindInstance(holdersProvider);

			Contexts.Instance.InitializeScope<GameScope>();
		}

		[TearDown]
		public void TearDown()
		{
			Destroy.AllGameObjectsOnScene();
		}

		[Test]
		public void WhenFactoryCreateCell_AndThereIsNoCells_ThenEntitiesCountShouldBe1()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);

			// Assert.
			Context.GetEntities().Length.Should().Be(1);
		}

		[Test]
		public void WhenFactoryCreateCell_AndXIs0YIs0_ThenCellCoordinatesShouldBeZeroBellow()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();

			// Act.
			var cellEntity = cellsFactory.Create(0, 0);

			// Assert.
			var cellCoordinates = cellEntity.GetCoordinates();
			cellCoordinates.Should().Be(Coordinates.Zero.WithLayer(Coordinates.Layer.Bellow));
		}
	}
}