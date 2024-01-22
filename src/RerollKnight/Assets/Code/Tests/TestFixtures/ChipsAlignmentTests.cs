using Code.Component;
using Entitas.Generic;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipsAlignmentTests : ZenjectUnitTestFixture
	{
		private Transform _holder;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		private static Entity<GameScope> NewPlayer => NewEntity.Is<Player>(true);
		private static Entity<GameScope> NewEntity => Context.CreateEntity();

		private static IChipConfig MockChipConfig => Mock.ChipConfig();

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.BindChipsFactory();

			_holder = Container.MockChipsHolder();
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test]
		public void _040_WhenChipsAligned_AndChipsCount1_ThenItsPositionShouldBeEqualToHolderPosition()
		{
			// Arrange.

			// Act.
			var chip = Create.Chip();

			// Assert.z
			var chipView = _holder.GetChild(0);
		}
	}
}