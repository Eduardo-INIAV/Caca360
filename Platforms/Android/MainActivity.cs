using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Webkit; // Adicione este using para acessar Android.Webkit

namespace caca360.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("MyWebView", (handler, view) =>
        {
            handler.PlatformView.Settings.JavaScriptEnabled = true;
#if ANDROID33_0_OR_GREATER
            handler.PlatformView.Settings.SetGeolocationEnabled(true);
#endif
            handler.PlatformView.SetWebChromeClient(new MyWebChromeClient());
        });
    }

    // Corrija o namespace e herança do MyWebChromeClient
    class MyWebChromeClient : WebChromeClient
    {
        public override void OnGeolocationPermissionsShowPrompt(string? origin, GeolocationPermissions.ICallback? callback)
        {
            callback?.Invoke(origin, true, false);
        }
    }
}
