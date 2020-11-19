#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Media.Imaging
{
	#if false || __IOS__ || NET461 || false || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class SvgImageSource : global::Windows.UI.Xaml.Media.ImageSource
	{
		#if false || __IOS__ || NET461 || false || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::Windows.Foundation.IAsyncOperation<global::Windows.UI.Xaml.Media.Imaging.SvgImageSourceLoadStatus> SetSourceAsync(global::Windows.Storage.Streams.IRandomAccessStream streamSource)
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<SvgImageSourceLoadStatus> SvgImageSource.SetSourceAsync(IRandomAccessStream streamSource) is not implemented in Uno.");
		}
		#endif
	}
}
