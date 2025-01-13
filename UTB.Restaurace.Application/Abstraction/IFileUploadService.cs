using Microsoft.AspNetCore.Http;

namespace UTB.Restaurace.Application.Abstraction
{
    public interface IFileUploadService
    {
        string FileUpload(IFormFile fileToUpload, string folderNameOnServer);
    }
}