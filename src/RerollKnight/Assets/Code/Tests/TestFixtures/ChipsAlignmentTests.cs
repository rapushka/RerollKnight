using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipsAlignmentTests : ZenjectUnitTestFixture
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
		public void _010_WhenChipsAligned_AndChipsCountIs1_ThenChipPositionShouldBeCenter()
		{
			// Arrange.
			var system = Container.Instantiate<AlignChipsCenterSystem>();

			// Act.
			var chip = Create.Chip(player: Create.Player(), isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var center = _holder.transform.position;
			chipPosition.Should().Be(center);
		}

		[Test]
		public void _020_WhenChipsAligned_AndChipsCountIs2_ThenFirstPositionShouldBeMinusHalfSpacing()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();
			var viewConfig = Container.Resolve<IViewConfig>();
			var spacing = viewConfig.MaxDistanceBetweenChips;
			var halfSpacing = spacing * 0.5f;

			// Act.
			var firstChip = Create.Chip(player: player, isVisible: true);
			Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = firstChip.GetDestinationOrActualPosition();
			var center = _holder.transform.position;
			chipPosition.Should().Be(center.Add(x: -halfSpacing));
		}

		[Test]
		public void _030_WhenChipsAligned_AndChipsCountIs2_ThenSecondPositionShouldBePlusHalfSpacing()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();
			var viewConfig = Container.Resolve<IViewConfig>();
			var spacing = viewConfig.MaxDistanceBetweenChips;
			var halfSpacing = spacing * 0.5f;

			// Act.
			Create.Chip(player: player, isVisible: true);
			var secondChip = Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = secondChip.GetDestinationOrActualPosition();
			var center = _holder.transform.position;
			chipPosition.Should().Be(center.Add(x: halfSpacing));
		}

		[Test]
		public void _040_WhenChipsAligned_AndChipsCountIs3_ThenFirstPositionShouldBeMinusSpacing()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();
			var viewConfig = Container.Resolve<IViewConfig>();
			var spacing = viewConfig.MaxDistanceBetweenChips;

			// Act.
			var firstChip = Create.Chip(player: player, isVisible: true);
			Create.Chip(player: player, isVisible: true);
			Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = firstChip.GetDestinationOrActualPosition();
			var center = _holder.transform.position;
			chipPosition.Should().Be(center.Add(x: -spacing));
		}

		[Test]
		public void _050_WhenChipsAligned_AndChipsCountIs3_ThenSecondPositionShouldBeCenter()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();

			// Act.
			Create.Chip(player: player, isVisible: true);
			var secondChip = Create.Chip(player: player, isVisible: true);
			Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = secondChip.GetDestinationOrActualPosition();
			var center = _holder.transform.position;
			chipPosition.Should().Be(center);
		}

		[Test]
		public void _060_WhenChipsAligned_AndChipsCountIs3_ThenThirdPositionShouldBePlusSpacing()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();
			var viewConfig = Container.Resolve<IViewConfig>();
			var spacing = viewConfig.MaxDistanceBetweenChips;

			// Act.
			Create.Chip(player: player, isVisible: true);
			Create.Chip(player: player, isVisible: true);
			var thirdChip = Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = thirdChip.GetDestinationOrActualPosition();
			var center = _holder.transform.position;
			chipPosition.Should().Be(center.Add(x: spacing));
		}
	}
}