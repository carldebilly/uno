using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Primitives;
using FluentAssertions;
using FluentAssertions.Execution;
using Uno.Extensions;
using Windows.UI.Xaml.Shapes;

namespace Uno.UI.Tests.RelativePanelTests
{
	[TestClass]
	public class Given_RelativePanel : Context
	{
		[TestMethod]
		public void When_Empty_And_MeasuredEmpty()
		{
			var SUT = new RelativePanel() { Name = "test" };

			SUT.Measure(default(Size));
			SUT.Arrange(default(Rect));

			using var _ = new AssertionScope();

			SUT.DesiredSize.Should().BeEmpty();
			SUT.GetChildren().Should().BeEmpty();
		}

		[TestMethod]
		public void When_XXX()
		{
			// +----sut-------------130------------------------+
			// | ----------+    height=50                      |
			// | | 30x30   |                                   |
			// | |         | +-------------------------------+ |
			// | | picture | | 10x100      text              | |
			// | |         | +-------------------------------+ |
			// | |         |                                   |
			// | ----------+                                   |
			// +-----------------------------------------------+


			var sut = new RelativePanel {Name = "sut", Height=50};
			var picture = new Ellipse {Name = "picture", Width = 30, Height = 30};
			var text = new TextBlock {Name = "text", Width = 100, Text = "Sample text", FontSize = 10};
			// var text = new Rectangle { Name = "text", Width = 100, Height=10 };
			RelativePanel.SetAlignVerticalCenterWithPanel(picture, true);
			RelativePanel.SetRightOf(text, "picture");
			RelativePanel.SetAlignVerticalCenterWithPanel(text, true);

			sut.Children.Add(picture);
			sut.Children.Add(text);

			sut.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

			var expectedSize = new Size(130, 50);
			sut.DesiredSize.Should().Be(expectedSize);
			sut.Arrange(new Rect(default, expectedSize));

			using var _ = new AssertionScope();
			LayoutInformation.GetLayoutSlot(picture).Should().Be(new Rect(0, 10, 30, 30), because: "picture position");
			LayoutInformation.GetLayoutSlot(text).Should().Be(new Rect(30, 20, 100, 10), because: "text position");
		}

		
	}
}
