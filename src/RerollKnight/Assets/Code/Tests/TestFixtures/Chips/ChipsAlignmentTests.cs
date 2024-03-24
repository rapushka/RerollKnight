// namespace Code.Editor.Tests
// {
// 	[TestFixture]
// 	public class ChipsAlignmentTests : ZenjectUnitTestFixture
// 	{
// 		private Transform _holder;
// 	
// 		[SetUp]
// 		public void SetUp()
// 		{
// 			Container.CommonBind();
// 			Container.BindChipsFactory();
// 	
// 			_holder = Container.MockChipsHolder();
// 		}
// 	
// 		[TearDown] public void TearDown() => Destroy.Everything();
// 	
// 		// Just to have less usages of the class from the Tests
// 		private AlignChipsVerticallySystem AlignChipsVerticallySystem
// 			=> Container.Instantiate<AlignChipsVerticallySystem>();
// 	
// 		[Test]
// 		public void _010_WhenChipsAligned_AndChipsCountIs1_ThenChipPositionShouldBeCenter()
// 		{
// 			// Arrange.
// 			var system = AlignChipsVerticallySystem;
// 	
// 			// Act.
// 			var chip = Create.Chip(player: Create.Player(), isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = chip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center, Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _020_WhenChipsAligned_AndChipsCountIs2_Then1stPositionShouldBeMinusHalfSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 			var halfSpacing = spacing * 0.5f;
// 	
// 			// Act.
// 			var firstChip = Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = firstChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: -halfSpacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _030_WhenChipsAligned_AndChipsCountIs2_Then2ndPositionShouldBePlusHalfSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 			var halfSpacing = spacing * 0.5f;
// 	
// 			// Act.
// 			Create.Chip(player: player, isVisible: true);
// 			var secondChip = Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = secondChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: halfSpacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _040_WhenChipsAligned_AndChipsCountIs3_Then1stPositionShouldBeMinusSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 	
// 			// Act.
// 			var firstChip = Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = firstChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: -spacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _050_WhenChipsAligned_AndChipsCountIs3_Then2ndPositionShouldBeCenter()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 	
// 			// Act.
// 			Create.Chip(player: player, isVisible: true);
// 			var secondChip = Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = secondChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center, Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _060_WhenChipsAligned_AndChipsCountIs3_Then3rdPositionShouldBePlusSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 	
// 			// Act.
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			var thirdChip = Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = thirdChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: spacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _070_WhenChipsAligned_AndChipsCountIs4_Then1stPositionShouldBeMinusOneAndHalfSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 			var oneAndHalfSpacing = spacing * 1.5f;
// 	
// 			// Act.
// 			var firstChip = Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = firstChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: -oneAndHalfSpacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _080_WhenChipsAligned_AndChipsCountIs4_Then2ndPositionShouldBeMinusHalfSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 			var halfSpacing = spacing * 0.5f;
// 	
// 			// Act.
// 			Create.Chip(player: player, isVisible: true);
// 			var secondChip = Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = secondChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: -halfSpacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _090_WhenChipsAligned_AndChipsCountIs4_Then3rdPositionShouldBePlusHalfSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 			var halfSpacing = spacing * 0.5f;
// 	
// 			// Act.
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			var thirdChip = Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = thirdChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: +halfSpacing), Constants.Tolerance);
// 		}
// 	
// 		[Test]
// 		public void _100_WhenChipsAligned_AndChipsCountIs4_Then4thPositionShouldBePlusOneAndHalfSpacing()
// 		{
// 			// Arrange.
// 			var player = Create.Player();
// 			var system = AlignChipsVerticallySystem;
// 			var viewConfig = Container.Resolve<IViewConfig>();
// 			var spacing = viewConfig.Chips.VerticalSpacing;
// 			var oneAndHalfSpacing = spacing * 1.5f;
// 	
// 			// Act.
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			Create.Chip(player: player, isVisible: true);
// 			var fourthChip = Create.Chip(player: player, isVisible: true);
// 			system.Execute();
// 	
// 			// Assert.
// 			var chipPosition = fourthChip.GetDestinationOrActualPosition();
// 			var center = _holder.transform.position;
// 			chipPosition.Should().BeApproximately(center.Add(x: +oneAndHalfSpacing), Constants.Tolerance);
// 		}
// 	}
// }