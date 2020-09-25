#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
using System;
using Windows.Foundation;
using Windows.UI.Text;

namespace Windows.UI.Xaml.Controls
{
	public partial class TextBlock : FrameworkElement
	{
		private void InitializePartial() { }

		private int GetCharacterIndexAtPoint(Point point) => -1;

		protected override Size MeasureOverride(Size availableSize)
		{
			var text = Text;
			var fontSize = FontSize;
			if (string.IsNullOrEmpty(text) || fontSize < 0.001 || availableSize.IsEmpty)
			{
				return default;
			}

			var availableWidth = availableSize.Width;
			var wrapMode = TextWrapping != TextWrapping.NoWrap && !double.IsInfinity(availableWidth);

			// Use a constant font size to simplify calculations
			var characterSize = new Size(fontSize*0.6, fontSize);
			var characterPerRow = wrapMode
				? Math.Min((uint)(availableWidth / characterSize.Width), 1)
				: uint.MaxValue;

			var numberOfRows = (text.Length / characterPerRow) + 1;

			return numberOfRows > 1
				? new Size(characterSize.Width*characterPerRow, characterSize.Height*numberOfRows)
				: new Size(characterSize.Width * text.Length, characterSize.Height);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			Console.WriteLine(finalSize);
			return base.ArrangeOverride(finalSize);
		}
	}
}
