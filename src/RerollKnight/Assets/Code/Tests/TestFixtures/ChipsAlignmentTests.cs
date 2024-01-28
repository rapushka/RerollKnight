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
		public void _010_WhenChipsAligned_AndChipsCountIs1_ThenChipPositionShouldBeHolderPosition()
		{
			// Arrange.
			var system = Container.Instantiate<AlignChipsCenterSystem>();

			// Act.
			var chip = Create.Chip(player: Create.Player(), isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = chip.GetDestinationOrActualPosition();
			var holderPosition = _holder.transform.position;
			chipPosition.Should().Be(holderPosition);
		}

		[Test]
		public void _020_WhenChipsAligned_AndChipsCountIs2_ThenFirstPositionShouldBeMinusHalfSpacing()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();
			var viewConfig = Container.Resolve<IViewConfig>();
			var spacing = viewConfig.MaxDistanceBetweenChips;
			var distanceFromCenter = spacing * 0.5f;

			// Act.
			var firstChip = Create.Chip(player: player, isVisible: true);
			Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = firstChip.GetDestinationOrActualPosition();
			var halfSpacingFromCenter = _holder.transform.position.Add(x: -distanceFromCenter);
			chipPosition.Should().Be(halfSpacingFromCenter);
		}

		[Test]
		public void _030_WhenChipsAligned_AndChipsCountIs2_ThenSecondPositionShouldBePlusHalfSpacing()
		{
			// Arrange.
			var player = Create.Player();
			var system = Container.Instantiate<AlignChipsCenterSystem>();
			var viewConfig = Container.Resolve<IViewConfig>();
			var spacing = viewConfig.MaxDistanceBetweenChips;
			var distanceFromCenter = spacing * 0.5f;

			// Act.
			Create.Chip(player: player, isVisible: true);
			var secondChip = Create.Chip(player: player, isVisible: true);
			system.Execute();

			// Assert.
			var chipPosition = secondChip.GetDestinationOrActualPosition();
			var halfSpacingFromCenter = _holder.transform.position.Add(x: distanceFromCenter);
			chipPosition.Should().Be(halfSpacingFromCenter);
		}
	}
}