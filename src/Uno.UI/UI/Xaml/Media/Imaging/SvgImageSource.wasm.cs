using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Windows.UI.Xaml.Media.Imaging
{
	partial class SvgImageSource
	{
		private BitmapImage _inner = new BitmapImage();

		public IAsyncOperation<SvgImageSourceLoadStatus> SetSourceAsync(IRandomAccessStream streamSource)
		{
			_inner.
			return AsyncOperation.FromTask(ct=>SetSourceAsyncInner(streamSource, ct));
		}

		private async Task<SvgImageSourceLoadStatus> SetSourceAsyncInner(IRandomAccessStream streamSource, CancellationToken ct)
		{
			try
			{
				await _innerSource.SetSourceAsync(streamSource);

				using var inputStream = streamSource.GetInputStreamAt(0);
				using var reader = new DataReader(inputStream);
				var readBytes = await reader.LoadAsync(uint.MaxValue);
				var buffer = new byte[readBytes];
				reader.ReadBytes(buffer);

				return SvgImageSourceLoadStatus.Success;
			}
			catch (Exception ex)
			{
				return SvgImageSourceLoadStatus.NetworkError;
			}
		}

		private protected override bool TryOpenSourceAsync(int? targetWidth, int? targetHeight, out Task<ImageData> asyncImage)
		{
			asyncImage = default;
			return false;
		}
	}
}
