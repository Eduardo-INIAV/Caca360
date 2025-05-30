using Microsoft.Maui.Devices.Sensors;

namespace caca360.Services;

public class LocationService
{
    public async Task<Location?> GetCurrentLocationAsync()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            return await Geolocation.GetLocationAsync(request);
        }
        catch
        {
            return null;
        }
    }

}
