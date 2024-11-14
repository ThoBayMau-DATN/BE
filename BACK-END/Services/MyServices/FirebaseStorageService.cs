using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Microsoft.Extensions.Configuration;

public class FirebaseStorageService
{
    private readonly StorageClient _storageClient;
    private readonly string _bucketName;

    public FirebaseStorageService(IConfiguration configuration)
    {
        var credential = GoogleCredential.FromFile("firebase-config.json");
        _storageClient = StorageClient.Create(credential);
        _bucketName = configuration["Firebase:StorageBucket"];
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        using var stream = file.OpenReadStream();
        var objectName = $"images/{fileName}";

        await _storageClient.UploadObjectAsync(_bucketName, objectName, file.ContentType, stream);

        return $"https://firebasestorage.googleapis.com/v0/b/{_bucketName}/o/{Uri.EscapeDataString(objectName)}?alt=media";
    }

    public async Task DeleteFileAsync(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        await _storageClient.DeleteObjectAsync(_bucketName, fileName);
    }
}
