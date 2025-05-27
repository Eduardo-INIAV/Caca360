using Microsoft.Maui.Devices.Sensors;

namespace caca360.Services;

public class LocationService
{
    public async Task<Location?> GetCurrentLocationAsync()
    {
        var request = new GeolocationRequest(GeolocationAccuracy.Medium);
        return await Geolocation.GetLocationAsync(request);
    }
}
