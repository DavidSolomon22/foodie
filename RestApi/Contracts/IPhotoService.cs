using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Contracts
{
    public interface IPhotoService
    {
        string UploadFile(IFormFile fileFromRequest);
        Task<MemoryStream> GetPhoto(string recipePhotoPath);
        void DeletePhoto(string recipePhotoPath);
        string GetContentType(string path);
        Dictionary<string, string> GetMimeTypes();
    }
}