using System;
using Code.Component;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class CellGenerationTests
	{
		private DiContainer _diContainer;
		private Transform _cellsHolder;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

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

		[Test] public void _000_WhenNothingIsHappening_ThenShouldBeNoException() { }

		[Test]
		public void _010_WhenFactoryCreateCell_AndThereIsNoCells_ThenEntitiesCountShouldBe1()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);

			// Assert.
			Context.GetEntities().Length.Should().Be(1);
		}

		[Test]
		public void _020_WhenFactoryCreateCell_AndXIs0YIs0_ThenCellCoordinatesShouldBeZeroBellow()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();

			// Act.
			var cellEntity = cellsFactory.Create(0, 0);

			// Assert.
			var cellCoordinates = cellEntity.GetCoordinates();
			cellCoordinates.Should().Be(Coordinates.Zero.WithLayer(Coordinates.Layer.Bellow));
		}

		[Test]
		public void _030_WhenFactoryCreateCell_AndThereIsAlreadyCellWithSameCoordinates_ThenThrowException()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();
			Action createSameCell = () => cellsFactory.Create(0, 0);

			// Act.
			createSameCell.Invoke();

			// Assert.
			createSameCell.Should().Throw<Entitas.EntityIndexException>();
		}

		[Test]
		public void _040_WhenFactoryCreateCell_ThenCellsHolderShouldHave1Child()
		{
			// Arrange.
			var cellsFactory = _diContainer.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);

			// Assert.
			_cellsHolder.childCount.Should().Be(1);
		}

		[Test]
		public void _050_WhenFactoryCreateCell_AndXIs0YIs0_ThenCellsPositionShouldBeSameAsHolderPosition()
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
		public void _060_WhenFactoryCreateCell_AndXIs1YIs1_ThenCellsPositionShouldBeSameAsTopDownCoordinates()
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
		public void _070_WhenFactoryCreateCell_AndXIs1YIs1_ThenCellsViewPositionShouldBeSameAsCellPosition()
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