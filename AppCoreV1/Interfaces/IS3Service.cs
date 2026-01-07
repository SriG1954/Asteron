using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Interfaces
{
    public interface IS3Service
    {
        Task<byte[]> DownloadFileAsync(string fileName);
        Task<bool> UploadFileAsync(IFormFile file);
        Task<bool> DeleteFileAsync(string fileName, string versionId = "");
    }
}
