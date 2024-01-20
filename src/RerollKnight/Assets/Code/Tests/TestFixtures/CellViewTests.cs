using Code.Component;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class CellViewTests
	{
		private DiContainer _diContainer;
		private Transform _cellsHolder;

		[SetUp]
		public void SetUp()
		{
			_diContainer = new DiContainer();
			_diContainer.Bind<CellsFactory>().AsSingle();

			_diContainer.Bind<IAssetsService>().To<AssetsService>().AsSingle();
			_diContainer.Bind<IResourcesService>().To<ResourcesService>().AsSingle();
			_diContainer.BindViewConfig();

			_cellsHolder = _diContainer.BindCellsHolder();
			_diContainer.Bind<Contexts>().FromInstance(Contexts.Instance).AsSingle();

			// ReSharper disable once ObjectCreationAsStatement - it'll still initialize contexts
			new ContextsInitializer(Contexts.Instance);
		}

		[TearDown]
		public void TearDown()
		{
			Destroy.All.GameObjects();
			Destroy.All.Entities<GameScope>();
		}

		[Test]
		public void _010_WhenFactoryCreateCell_AndXIs0YIs0_ThenCellsPositionShouldBeSameAsHolderPosition()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);

			// Assert.
			var cellViewTransform = _cellsHolder.GetChild(0);
			cellViewTransform.position.Should().Be(_cellsHolder.transform.position);
		}

		[Test]
		public void _020_WhenFactoryCreateCell_AndXIs1YIs1_ThenCellsPositionShouldBeSameAsTopDownCoordinates()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();
			var system = _diContainer.Instantiate<SetPositionFromCoordinatesSystem>();
			var eventSystem = new SelfEventSystem<GameScope, Position>(Contexts.Instance);

			// Act.
			var cellEntity = cellsFactory.Create(1, 1);
			system.Execute();
			eventSystem.Execute();

			// Assert.
			var cellCoordinates = cellEntity.GetCoordinates();
			var cellPosition = cellEntity.Get<Position>().Value;

			cellPosition.Should().Be(cellCoordinates.ToTopDown());
		}

		[Test]
		public void _030_WhenFactoryCreateCell_AndXIs1YIs1_ThenCellsViewPositionShouldBeSameAsCellPosition()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();
			var system = _diContainer.Instantiate<SetPositionFromCoordinatesSystem>();
			var eventSystem = new SelfEventSystem<GameScope, Position>(Contexts.Instance);

			// Act.
			var cellEntity = cellsFactory.Create(1, 1);
			system.Execute();
			eventSystem.Execute();

			// Assert.
			var cellView = _cellsHolder.GetChild(0);
			var cellPosition = cellEntity.Get<Position>().Value;
			cellView.position.Should().Be(cellPosition);
		}
	}
}