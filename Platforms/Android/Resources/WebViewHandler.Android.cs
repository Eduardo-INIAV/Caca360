// WebViewHandler.Android.cs
#if ANDROID
using Microsoft.Maui.Handlers;
using AndroidWebView = Android.Webkit.WebView;

namespace caca360.Platforms.Android.Resources
{
    public partial class WebViewHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null)
        : ViewHandler<IWebView, AndroidWebView>(mapper, commandMapper), IWebViewHandler
    {
        protected override AndroidWebView CreatePlatformView()
        {
            return new AndroidWebView(Context);
        }

        protected override void ConnectHandler(AndroidWebView nativeView)
        {
            base.ConnectHandler(nativeView);

            nativeView.SetWebChromeClient(new CustomWebViewHandler(this));
        }
    }
}
#endif
