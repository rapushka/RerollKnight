using Code.Component;
using FluentAssertions;
using NUnit.Framework;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipViewPositionTests : ZenjectUnitTestFixture
	{
		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.BindChipsFactory();

			Container.MockChipsHolder();
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test]
		public void _010_WhenChipCreated_AndItIsVisibleAndAvailable_ThenYShouldBeDefaultY()
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
			var defaultY = viewConfig.Chips.DefaultOffset;
			chipPosition.y.Should().BeApproximately(defaultY, Constants.Tolerance);
		}

		[Test]
		public void _020_WhenChipCreated_AndItIsUnavailable_ThenYShouldBeUnavailableY()
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
			var unavailableY = viewConfig.Chips.UnavailableOffset;
			chipPosition.y.Should().BeApproximately(unavailableY, Constants.Tolerance);
		}

		[Test]
		public void _030_WhenChipCreated_AndItIsInvisible_ThenYShouldBeInvisibleY()
		{
			// Arrange.
			var player = Create.Player();
			var viewConfig = Container.Resolve<IViewConfig>();
			var system = Container.Instantiate<UpdateChipsPositionSystem>();

			// Act.
			var chip = Create.Chip(player: player, isVisible: false);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var invisibleY = viewConfig.Chips.InvisibleOffset;
			chipPosition.y.Should().BeApproximately(invisibleY, Constants.Tolerance);
		}

		[Test]
		public void _040_WhenChipCreated_AndItIsInvisibleAndUnavailable_ThenYShouldBeInvisibleY()
		{
			// Arrange.
			var player = Create.Player();
			var viewConfig = Container.Resolve<IViewConfig>();
			var system = Container.Instantiate<UpdateChipsPositionSystem>();

			// Act.
			var chip = Create.Chip(player: player, isVisible: false);
			chip.Is<AvailableToPick>(false);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var invisibleY = viewConfig.Chips.InvisibleOffset;
			chipPosition.y.Should().BeApproximately(invisibleY, Constants.Tolerance);
		}

		[Test]
		public void _050_WhenChipCreated_AndItIsPicked_ThenYShouldBePickedY()
		{
			// Arrange.
			var player = Create.Player();
			var viewConfig = Container.Resolve<IViewConfig>();
			var system = Container.Instantiate<UpdateChipsPositionSystem>();

			// Act.
			var chip = Create.Chip(player: player);
			chip.Is<PickedChip>(true);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var invisibleY = viewConfig.Chips.PickedOffset;
			chipPosition.y.Should().BeApproximately(invisibleY, Constants.Tolerance);
		}
	}
}