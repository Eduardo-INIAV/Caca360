using Firebase.Storage;

namespace caca360.Services
{
    public class StorageService
    {
        private readonly string _bucket = "caca360-app.appspot.com";

        public async Task<string> UploadPhotoAsync(Stream imageStream, string userId)
        {
            var fileName = $"{Guid.NewGuid()}.jpg";
            var folder = $"profileImages/{userId}";
            var storage = new FirebaseStorage(_bucket);
            var imageRef = storage.Child(folder).Child(fileName);

            await imageRef.PutAsync(imageStream);
            var downloadUrl = await imageRef.GetDownloadUrlAsync();
            return downloadUrl;
        }
    }
}
