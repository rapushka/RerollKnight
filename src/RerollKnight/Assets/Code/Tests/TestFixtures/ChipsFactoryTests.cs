using Code.Component;
using Entitas;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipsFactoryTests : ZenjectUnitTestFixture
	{
		private Transform _holder;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		private static IGroup<Entity<GameScope>> Chips => Context.GetGroup(ScopeMatcher<GameScope>.Get<Chip>());

		private static Entity<GameScope> NewPlayer => NewEntity.Is<Player>(true);
		private static Entity<GameScope> NewEntity => Context.CreateEntity();

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.BindChipsFactory();

			_holder = Container.MockChipsHolder();
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test]
		public void _010_WhenCreateChip_ThenChipsCountShouldBe1()
		{
			// Arrange.
			var chipsFactory = Container.Resolve<ChipsFactory>();

			// Act.
			chipsFactory.Create(Mock.ChipConfig(), NewEntity, NewEntity);

			// Assert.
			var chipsCount = Chips.GetEntities().Length;
			chipsCount.Should().Be(1);
		}

		[Test]
		public void _020_WhenCreateChip_AndOwnerDiceIsPlayer_ThenChipViewsCountShouldBe1()
		{
			// Arrange.
			var chipsFactory = Container.Resolve<ChipsFactory>();

			// Act.
			chipsFactory.Create(Mock.ChipConfig(), NewPlayer, NewEntity);

			// Assert.
			var chipViewsCount = _holder.childCount;
			chipViewsCount.Should().Be(1);
		}

		[Test]
		public void _030_WhenCreate2Chips_AndOwnerDiceIsPlayer_ThenChipViewsCountShouldBe2()
		{
			// Arrange.
			var chipsFactory = Container.Resolve<ChipsFactory>();
			var player = NewPlayer;
			var side = NewEntity;

			// Act.
			chipsFactory.Create(Mock.ChipConfig(), player, side);
			chipsFactory.Create(Mock.ChipConfig(), player, side);

			// Assert.
			var chipViewsCount = _holder.childCount;
			chipViewsCount.Should().Be(2);
		}
	}
}