using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Contracts
{
    public interface IPhotoService
    {
        string UploadFile(IFormFile fileFromRequest);
        Task<MemoryStream> GetPhoto(string photoPath);
        void DeletePhoto(string photoPath);
        string GetContentType(string path);
        Dictionary<string, string> GetMimeTypes();
    }
}