using System;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class CellFactoryTests : ZenjectUnitTestFixture
	{
		private Transform _cellsHolder;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.Bind<CellsFactory>().AsSingle();

			_cellsHolder = Container.MockCellsHolder();
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test] public void _000_WhenNothingIsHappening_ThenShouldBeNoException() { }

		[Test]
		public void _010_WhenFactoryCreateCell_AndThereIsNoCells_ThenEntitiesCountShouldBe1()
		{
			// Arrange.
			var cellsFactory = Container.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);

			// Assert.
			Context.GetEntities().Length.Should().Be(1);
		}

		[Test]
		public void _020_WhenFactoryCreateCell_AndXIs0YIs0_ThenCellCoordinatesShouldBeZeroBellow()
		{
			// Arrange.
			var cellsFactory = Container.Resolve<CellsFactory>();

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
			var cellsFactory = Container.Resolve<CellsFactory>();
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
			var cellsFactory = Container.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);

			// Assert.
			_cellsHolder.childCount.Should().Be(1);
		}

		[Test]
		public void _045_WhenFactoryCreate2Cells_ThenCellsHolderShouldHave2Children()
		{
			// Arrange.
			var cellsFactory = Container.Resolve<CellsFactory>();

			// Act.
			cellsFactory.Create(0, 0);
			cellsFactory.Create(0, 1);

			// Assert.
			_cellsHolder.childCount.Should().Be(2);
		}
	}
}