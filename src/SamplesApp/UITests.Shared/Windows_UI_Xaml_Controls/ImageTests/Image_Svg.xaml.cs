using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Uno.UI.Samples.Controls;

namespace UITests.Windows_UI_Xaml_Controls.ImageTests
{
	[Sample("Image")]

	public sealed partial class Image_Svg : Page
	{
		public Image_Svg()
		{
			this.InitializeComponent();
		}

		private void LoadClicked(object sender, RoutedEventArgs e)
		{
			log.Text = "";
			var uri = new Uri(url.Text);
			ImageSource source = null;

			var mode = (sender as FrameworkElement)?.Tag as string;
			Log($"Loading {url.Text} using {mode}...");
			switch (mode)
			{
				case "BitmapImage":
				{
					var bitmapSource = new BitmapImage(uri);
					source = bitmapSource;
					bitmapSource.DownloadProgress += (snd, evt) => Log($"Downloadind... {evt.Progress}%");
					bitmapSource.ImageFailed += (snd, evt) => Log($"ERROR: {evt.ErrorMessage}");
					bitmapSource.ImageOpened += (snd, evt) => Log($"LOADED from {evt.OriginalSource}");
					break;
				}
				case "SvgImageSource":
				{
					var svgSource = new SvgImageSource(uri);
					source = svgSource;
					svgSource.OpenFailed += (snd, evt) => Log($"ERROR: {evt.Status}");
					svgSource.Opened += (snd, evt) => Log("LOADED");
					break;
				}
				case "SvgImageSource2":
				{
					var border = img1.Parent as FrameworkElement;
					var svgSource = new SvgImageSource(uri);
					source = svgSource;
					Log($"RasterizePixelWidth/Height: {border.ActualWidth}x{border.ActualHeight}");
					svgSource.RasterizePixelWidth = border.ActualWidth;
					svgSource.RasterizePixelHeight = border.ActualHeight;
					svgSource.OpenFailed += (snd, evt) => Log($"ERROR: {evt.Status}");
					svgSource.Opened += (snd, evt) => Log("LOADED");
					break;
				}
			}
			img1.Source = source;

			void Log(string msg)
			{
				log.Text += msg + "\n";
			}
		}
	}
}
