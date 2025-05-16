#if ANDROID
using Android.Webkit;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace caca360.Platforms.Android.Resources
{
    internal class CustomWebViewHandler(IWebViewHandler handler) : MauiWebChromeClient(handler)
    {
        public override async void OnPermissionRequest(PermissionRequest? request)
        {
            foreach (var resource in request.GetResources())
            {
                if (resource.Equals("android.webkit.resource.GEOLOCATION", StringComparison.OrdinalIgnoreCase))
                {
                    // Solicita permissão de localização se ainda não foi concedida
                    var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                    if (status != PermissionStatus.Granted)
                        request.Deny();
                    else
                        request.Grant(request.GetResources());

                    return;
                }
            }

            base.OnPermissionRequest(request);
        }
    }
}
#endif
