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

		[Repeat(2)]
		[Test] public void _000_WhenNothingIsHappening_ThenShouldBeNoException() { }

		[Test]
		public void _010_WhenFactoryCreateCell_AndThereIsNoCells_ThenEntitiesCountShouldBe1()
		{
			// Arrange.
			// Act.
			Create.Cell(0, 0);

			// Assert.
			Context.GetEntities().Length.Should().Be(1);
		}

		[Test]
		public void _020_WhenFactoryCreateCell_AndXIs0YIs0_ThenCellCoordinatesShouldBeZeroBellow()
		{
			// Arrange.
			// Act.
			var cellEntity = Create.Cell(0, 0);

			// Assert.
			var cellCoordinates = cellEntity.GetCoordinates();
			cellCoordinates.Should().Be(Coordinates.Zero.WithLayer(Coordinates.Layer.Bellow));
		}

		[Test]
		public void _030_WhenFactoryCreateCell_AndThereIsAlreadyCellWithSameCoordinates_ThenThrowException()
		{
			// Arrange.
			Action createSameCell = () => Create.Cell(0, 0);

			// Act.
			createSameCell.Invoke();

			// Assert.
			createSameCell.Should().Throw<Entitas.EntityIndexException>();
		}

		[Test]
		public void _040_WhenFactoryCreateCell_ThenCellsHolderShouldHave1Child()
		{
			// Arrange.

			// Act.
			Create.Cell(0, 0);

			// Assert.
			_cellsHolder.childCount.Should().Be(1);
		}

		[Test]
		public void _045_WhenFactoryCreate2Cells_ThenCellsHolderShouldHave2Children()
		{
			// Arrange.

			// Act.
			Create.Cell(0, 0);
			Create.Cell(0, 1);

			// Assert.
			_cellsHolder.childCount.Should().Be(2);
		}
	}
}