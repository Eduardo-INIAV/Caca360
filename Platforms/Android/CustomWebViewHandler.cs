#if ANDROID
using Android.Webkit;
using Microsoft.Maui.Handlers;



public class CustomWebViewHandler : WebViewHandler
{
    protected override void ConnectHandler(Android.Webkit.WebView platformView)
    {
        base.ConnectHandler(platformView);
        platformView.Settings.JavaScriptEnabled = true;
        platformView.Settings.SetGeolocationEnabled(true);
        platformView.SetWebChromeClient(new CustomWebChromeClient());
    }
}

public class CustomWebChromeClient : WebChromeClient
{
    public override void OnGeolocationPermissionsShowPrompt(string? origin, GeolocationPermissions.ICallback? callback)
    {
        callback.Invoke(origin, allow: true, retain: false);
    }
}

#endif
