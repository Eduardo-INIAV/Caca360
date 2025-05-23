using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Webkit;
using AndroidX.Core.Content;  // necessário para FileProvider
using Uri = Android.Net.Uri;

namespace caca360.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme",
          MainLauncher = true,
          LaunchMode = LaunchMode.SingleTop,
          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    internal static IValueCallback? filePathCallback;
    private const int FileChooserRequestCode = 1000;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("MyWebView", (handler, view) =>
        {
            var androidWebView = handler.PlatformView;
            androidWebView.Settings.JavaScriptEnabled = true;
            androidWebView.Settings.AllowFileAccess = true;
            androidWebView.Settings.AllowContentAccess = true;

#if ANDROID33_0_OR_GREATER
            androidWebView.Settings.SetGeolocationEnabled(true);
#endif

            androidWebView.SetWebChromeClient(new MyWebChromeClient(this));
        });
    }

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        if (requestCode == FileChooserRequestCode && filePathCallback != null)
        {
            Uri[]? results = null;

            if (resultCode == Result.Ok)
            {
                if (data != null)
                {
                    if (data.Data != null)
                    {
                        results = [data.Data];
                    }
                    else if (data.ClipData != null && data.ClipData.ItemCount > 0)
                    {
                        int count = data.ClipData.ItemCount;
                        results = new Uri[count];
                        for (int i = 0; i < count; i++)
                        {
                            results[i] = data.ClipData.GetItemAt(i).Uri;
                        }
                    }
                }
            }
            else if (resultCode == Result.Canceled)
            {
                // ← Esta parte estava a faltar
                results = null;
            }

            filePathCallback.OnReceiveValue(results);
            filePathCallback = null;
        }
    }

    private Java.IO.File CreateImageFile()
    {
        string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string imageFileName = "JPEG_" + timeStamp + "_";
        Java.IO.File storageDir = GetExternalFilesDir(global::Android.OS.Environment.DirectoryPictures);
        Java.IO.File image = Java.IO.File.CreateTempFile(imageFileName, ".jpg", storageDir);
        return image;
    }

    private class MyWebChromeClient : WebChromeClient
    {
        private readonly Activity activity;
        public MyWebChromeClient(Activity activity) => this.activity = activity;

        public override bool OnShowFileChooser(global::Android.Webkit.WebView? webView, IValueCallback? filePathCallback, FileChooserParams? fileChooserParams)
        {
            MainActivity.filePathCallback?.OnReceiveValue(null);
            MainActivity.filePathCallback = filePathCallback;

            Intent cameraIntent = new(MediaStore.ActionImageCapture);
            Java.IO.File imageFile = ((MainActivity)activity).CreateImageFile();
            Uri imageUri = AndroidX.Core.Content.FileProvider.GetUriForFile(activity, $"{activity.PackageName}.fileprovider", imageFile);
            cameraIntent.PutExtra(MediaStore.ExtraOutput, imageUri);

            Intent contentSelectionIntent = new Intent(Intent.ActionGetContent);
            contentSelectionIntent.AddCategory(Intent.CategoryOpenable);
            contentSelectionIntent.SetType("image/*");

            Intent[] intentArray = { cameraIntent };
            Intent chooserIntent = Intent.CreateChooser(contentSelectionIntent, "Escolhe a fonte da imagem");
            chooserIntent.PutExtra(Intent.ExtraInitialIntents, intentArray);

            activity.StartActivityForResult(chooserIntent, FileChooserRequestCode);

            return true;
        }

        public override void OnGeolocationPermissionsShowPrompt(string? origin, GeolocationPermissions.ICallback? callback)
        {
            callback?.Invoke(origin, true, false);
        }
    }
}
