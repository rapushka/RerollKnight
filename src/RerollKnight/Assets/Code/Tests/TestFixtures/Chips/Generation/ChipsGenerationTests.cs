using System.Linq;
using Code.Component;
using FluentAssertions;
using NUnit.Framework;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipsGenerationTests : ZenjectUnitTestFixture
	{
		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();

			Container.Bind<ChipsConfig>().FromResources(Constants.ResourcePath.ChipsConfig);
		}

		[TearDown] public void TearDown() => Destroy.Everything();

		[Test]
		public void _010_WhenCreateChipSet_AndDiceHas1Side_ThenSidesCountShouldBeEqualsToChipsSetChipForFacesCount()
		{
			// Arrange.
			var enemy = Create.Enemy();
			Create.Side(enemy);

			// Act.
			var chipsSet = new ChipsSet(enemy, Container.Resolve<ChipsConfig>());

			// Assert.
			var faces = enemy.GetDependants().Where((e) => e.Has<Face>());
			faces.Should().HaveSameCount(chipsSet.ChipsForFaces);
		}
	}
}