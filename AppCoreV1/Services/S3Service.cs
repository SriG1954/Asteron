using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using AppCoreV1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Net;

namespace AppCoreV1.Services
{
    public class S3Service: IS3Service, IDisposable
    {
        private readonly IConfiguration _Configuration;
        private AmazonS3Client _s3client;
        private string awsAccessKey;
        private string awsSecretKey;
        private string region;
        private string bucketName;

        public S3Service(IConfiguration Configuration)
        {
            _Configuration = Configuration;
            awsAccessKey = _Configuration.GetSection("AWS:awsAccessKey").Value ?? string.Empty;
            awsSecretKey = _Configuration.GetSection("AWS:awsSecretKey").Value ?? string.Empty;
            region = _Configuration.GetSection("AWS:region").Value ?? string.Empty;
            bucketName = _Configuration.GetSection("AWS:bucketName").Value ?? string.Empty;
            _s3client = new AmazonS3Client(awsAccessKey, awsSecretKey, RegionEndpoint.GetBySystemName(region));

        }

        public async Task<byte[]> DownloadFileAsync(string fileName)
        {
            MemoryStream ms = null!;
            bucketName = "samplev106feb2023";
            fileName = "Root1/Documents/Feb2023/CopiedDocumentsList.txt";

            try
            {
                GetObjectRequest getObjectRequest = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = fileName
                };

                using (var response = await _s3client.GetObjectAsync(getObjectRequest))
                {
                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        using (ms = new MemoryStream())
                        {
                            await response.ResponseStream.CopyToAsync(ms);
                        }
                    }
                }

                if (ms is null || ms.ToArray().Length < 1)
                    throw new FileNotFoundException(string.Format("The document '{0}' is not found", fileName));

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                string strEx = ex.ToString();
                throw;
            }
        }

        public async Task<bool> UploadFileAsync(IFormFile file)
        {
            try
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = file.FileName,
                        BucketName = bucketName,
                        ContentType = file.ContentType
                    };

                    var fileTransferUtility = new TransferUtility(_s3client);

                    await fileTransferUtility.UploadAsync(uploadRequest);

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteFileAsync(string fileName, string versionId = "")
        {
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = fileName
            };

            if (!string.IsNullOrEmpty(versionId))
                request.VersionId = versionId;

            await _s3client.DeleteObjectAsync(request);
            return true;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
