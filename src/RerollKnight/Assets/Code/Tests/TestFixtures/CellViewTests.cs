using Code.Component;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class CellViewTests : ZenjectUnitTestFixture
	{
		private Transform _cellsHolder;

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.Bind<CellsFactory>().AsSingle();

			_cellsHolder = Container.BindCellsHolder();
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
			var cellsFactory = Container.Resolve<CellsFactory>();

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
			var cellsFactory = Container.Resolve<CellsFactory>();
			var system = Container.Instantiate<SetPositionFromCoordinatesSystem>();
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
			var cellsFactory = Container.Resolve<CellsFactory>();
			var system = Container.Instantiate<SetPositionFromCoordinatesSystem>();
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