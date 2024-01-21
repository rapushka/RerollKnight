using Code.Component;
using Entitas;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipsFactoryTests : ZenjectUnitTestFixture
	{
		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		private static IGroup<Entity<GameScope>> Chips => Context.GetGroup(ScopeMatcher<GameScope>.Get<Chip>());

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.Bind<ChipsFactory>().AsSingle();

			Container.Mock<IAbilitiesFactory>();
			Container.Mock<IHoldersProvider>();
			Container.Mock<IChipDescriptionBuilder>();
		}

		[Test]
		public void _010_WhenCreateChip_ThenChipsCountShouldBe1()
		{
			// Arrange.
			var chipsFactory = Container.Resolve<ChipsFactory>();
			var diceEntity = Context.CreateEntity();
			var faceEntity = Context.CreateEntity();

			// Act.
			chipsFactory.Create(Mock.ChipConfig(), diceEntity, faceEntity);

			// Assert.
			var chips = Chips.GetEntities();
			chips.Length.Should().Be(1);
		}
	}
}