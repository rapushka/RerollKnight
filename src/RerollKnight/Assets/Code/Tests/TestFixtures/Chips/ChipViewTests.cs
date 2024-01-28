using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Code.Editor.Tests
{
	[TestFixture]
	public class ChipViewTests : ZenjectUnitTestFixture
	{
		private Transform _chipsHolder;

		[SetUp]
		public void SetUp()
		{
			Container.CommonBind();
			Container.Bind<CellsFactory>().AsSingle();

			_chipsHolder = Container.MockChipsHolder();
		}

		[TearDown] public void TearDown() => Destroy.Everything();
	}
}