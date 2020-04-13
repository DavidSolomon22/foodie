using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;

namespace RestApi.Utility
{
    public class PhotoService : IPhotoService
    {
        public string UploadFile(IFormFile fileFromRequest)
        {
            if (fileFromRequest != null)
            {
                var getExtension = fileFromRequest.ContentType.Split('/');

                var fileExtension = getExtension[1].ToString().ToUpper();

                if (fileExtension != "JPG" && fileExtension != "JPEG" && fileExtension != "PNG")
                {
                    throw new System.ArgumentOutOfRangeException("fileFromRequest extension is wrong");
                }

                var fileName = Path.GetRandomFileName() + '.' + fileExtension;

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Resources", "Images", fileName));

                using (var stream = new FileStream(pathToSave, FileMode.Create))
                {
                    fileFromRequest.CopyTo(stream);
                }

                return pathToSave;
            }
            else
            {
                return null;
            }
        }

        public void DeletePhoto(string recipePhotoPath)
        {
            if (recipePhotoPath != null)
            {
                 File.Delete(recipePhotoPath);
            }
        }

        public async Task<MemoryStream> GetRecipePhoto(string recipePhotoPath)
        {
            var photoStream = new MemoryStream();

            using (var stream = new FileStream(recipePhotoPath, FileMode.Open))
            {
                await stream.CopyToAsync(photoStream);
            }

            photoStream.Position = 0;

            return photoStream;
        }
        
        public string GetContentType(string path)
        {
            var contenTypes = GetMimeTypes();

            var extension = Path.GetExtension(path).ToLowerInvariant();

            return contenTypes[extension];
        }

        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats  officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}