#nullable enable
using System;
using System.ComponentModel;

namespace Windows.UI.Xaml.Media.Imaging
{
	public partial class SvgImageSource : ImageSource
	{
		public Uri UriSource
		{
			get => (Uri)GetValue(UriSourceProperty);
			set => SetValue(UriSourceProperty, value);
		}

		public double RasterizePixelWidth
		{
			get => (double)GetValue(RasterizePixelWidthProperty);
			set => SetValue(RasterizePixelWidthProperty, value);
		}

		public double RasterizePixelHeight
		{
			get => (double)GetValue(RasterizePixelHeightProperty);
			set => SetValue(RasterizePixelHeightProperty, value);
		}

		public static DependencyProperty RasterizePixelHeightProperty { get; } =
		DependencyProperty.Register(
			nameof(RasterizePixelHeight), typeof(double),
			typeof(SvgImageSource),
			new FrameworkPropertyMetadata(default(double)));

		public static DependencyProperty RasterizePixelWidthProperty { get; } =
		DependencyProperty.Register(
			nameof(RasterizePixelWidth), typeof(double),
			typeof(SvgImageSource),
			new FrameworkPropertyMetadata(default(double)));

		public static DependencyProperty UriSourceProperty { get; } =
		DependencyProperty.Register(
			nameof(UriSource), typeof(Uri),
			typeof(SvgImageSource),
			new FrameworkPropertyMetadata(default(Uri)));

		public SvgImageSource()
		{
		}

		public SvgImageSource(Uri uriSource)
		{
		}

		public event Foundation.TypedEventHandler<SvgImageSource, SvgImageSourceFailedEventArgs>? OpenFailed;

		public event Foundation.TypedEventHandler<SvgImageSource, SvgImageSourceOpenedEventArgs>? Opened;
	}
}
