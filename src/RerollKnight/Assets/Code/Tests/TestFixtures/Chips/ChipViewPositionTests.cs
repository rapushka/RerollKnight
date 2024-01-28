using Code.Component;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipViewPositionTests : ZenjectUnitTestFixture
	{
		private Transform _holder;

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.BindChipsFactory();

			_holder = Container.MockChipsHolder();
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test]
		public void _010_WhenChipCreated_AndHasNoConditions_ThenYShouldBeDefault()
		{
			// Arrange.
			var player = Create.Player();
			var viewConfig = Container.Resolve<IViewConfig>();
			var system = Container.Instantiate<UpdateChipsPositionSystem>();

			// Act.
			var chip = Create.Chip(player: player, isVisible: true);
			chip.Is<AvailableToPick>(true);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var defaultY = viewConfig.DefaultChipPositionY;
			chipPosition.y.Should().BeApproximately(defaultY, Constants.Tolerance);
		}

		[Test]
		public void _020_WhenChipCreated_AndItIsUnavailable_ThenYShouldBeUnavailableHeight()
		{
			// Arrange.
			var player = Create.Player();
			var viewConfig = Container.Resolve<IViewConfig>();
			var system = Container.Instantiate<UpdateChipsPositionSystem>();

			// Act.
			var chip = Create.Chip(player: player, isVisible: true);
			chip.Is<AvailableToPick>(false);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var unavailableY = viewConfig.UnavailableChipPositionY;
			chipPosition.y.Should().BeApproximately(unavailableY, Constants.Tolerance);
		}
	}
}