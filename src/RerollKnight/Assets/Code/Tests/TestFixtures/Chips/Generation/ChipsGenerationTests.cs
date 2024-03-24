using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using FluentAssertions;
using NUnit.Framework;
using Zenject;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;
// ReSharper disable UnusedMember.Local

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipsGenerationTests : ZenjectUnitTestFixture
	{
		private IGroup<GameEntity> _chips;
		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.BindChipsFactory();

			Container.Bind<ChipsConfig>().FromResources(Constants.ResourcePath.ChipsConfig).AsSingle();
			Container.Bind<ChipsGenerator>().AsSingle();

			_chips = Context.GetGroup(ScopeMatcher<GameScope>.Get<Chip>());
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test]
		public void _010_WhenCreateChipSet_AndDiceHas1Side_ThenSidesCountShouldBeEqualsToChipsSetChipForFacesCount()
		{
			// Arrange.
			var chipsConfig = Container.Resolve<ChipsConfig>();
			var enemy = Create.Enemy();
			Create.Side(enemy);

			// Act.
			var faces = enemy.GetDependants().Where((e) => e.Has<Face>()).ToArray();
			var chipsSet = ChipsSet.FillForActor(faces.Length, enemy.Is<Enemy>(), chipsConfig);

			// Assert.
			faces.Should().HaveSameCount(chipsSet.ChipsForFaces);
		}

		[Test]
		public void _020_WhenCreate2ChipSets_AndForTheSameSidesCount_ThenChipsShouldBeSame()
		{
			// // Arrange.
			// const int sideCount = 4;
			//
			// var chipsGenerator = Container.Resolve<ChipsGenerator>();
			//
			// var firstDice = Create.Dice(sideCount);
			// var secondDice = Create.Dice(sideCount);
			//
			// // Act.
			// chipsGenerator.CreateChipsFor(firstDice);
			// chipsGenerator.CreateChipsFor(secondDice);
			//
			// // Assert.
			// var firstDiceChips = DiceChips(firstDice);
			// var secondDiceChips = DiceChips(secondDice);
			//
			// foreach (var (first, second) in firstDiceChips.Zip(secondDiceChips, (f, s) => (f, s)))
			// 	first.Get<Label>().Should().BeSameAs(second.Get<Label>());
		}

		[Test]
		public void _030_WhenCreate2ChipSets_AndForDifferentSidesCount_ThenChipsShouldBeDifferent()
		{
			// // Arrange.
			// const int firstDiceSideCount = 4;
			// const int secondDiceSideCount = 6;
			//
			// var chipsGenerator = Container.Resolve<ChipsGenerator>();
			//
			// var firstDice = Create.Dice(firstDiceSideCount);
			// var secondDice = Create.Dice(secondDiceSideCount);
			//
			// // Act.
			// chipsGenerator.CreateChipsFor(firstDice);
			// chipsGenerator.CreateChipsFor(secondDice);
			//
			// // Assert.
			// var firstDiceChips = DiceChips(firstDice);
			// var secondDiceChips = DiceChips(secondDice);
			// firstDiceChips.Should().NotBeSameAs(secondDiceChips);
		}

		private IEnumerable<GameEntity> DiceChips(GameEntity dice)
			=> _chips.Where((c) => c.GetOwner().IsBelongTo(dice)).OrderBy((c) => c.creationIndex);
	}
}