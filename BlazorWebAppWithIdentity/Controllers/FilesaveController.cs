﻿using Business.Models;
using Core.Movie.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorWebAppWithIdentity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesaveController(IHostEnvironment env, ILogger<FilesaveController> logger, IMediaApi mediaApi) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<IList<UploadResultEventArgs>>> PostFile(
            [FromForm] IEnumerable<IFormFile> files)
        {
            var maxAllowedFiles = 3;
            long maxFileSize = 1024 * 1024 * 15;
            var filesProcessed = 0;
            var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
            List<UploadResultEventArgs> uploadResults = [];

            foreach (var file in files)
            {
                var uploadResult = new UploadResultEventArgs();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;
                var trustedFileNameForDisplay =
                    WebUtility.HtmlEncode(untrustedFileName);

                if (filesProcessed < maxAllowedFiles)
                {
                    if (file.Length == 0)
                    {
                        logger.LogInformation("{FileName} length is 0 (Err: 1)",
                            trustedFileNameForDisplay);
                        uploadResult.ErrorCode = 1;
                    }
                    else if (file.Length > maxFileSize)
                    {
                        logger.LogInformation("{FileName} of {Length} bytes is " +
                            "larger than the limit of {Limit} bytes (Err: 2)",
                            trustedFileNameForDisplay, file.Length, maxFileSize);
                        uploadResult.ErrorCode = 2;
                    }
                    else
                    {
                        try
                        {
                            Guid meidUid = Guid.NewGuid();
                            trustedFileNameForFileStorage = meidUid.ToString() + Path.GetExtension(file.FileName);
                            var path = Path.Combine(env.ContentRootPath,
                                env.EnvironmentName, "unsafe_uploads",
                                trustedFileNameForFileStorage);

                            await using FileStream fs = new(path, FileMode.Create);
                            await file.CopyToAsync(fs);

                            logger.LogInformation("{FileName} saved at {Path}",
                                trustedFileNameForDisplay, path);
                            uploadResult.Uploaded = true;
                            uploadResult.StoredFileName = trustedFileNameForFileStorage;

                            var media = new Dto.Media
                            {
                                Uid = meidUid,
                                FileName = trustedFileNameForFileStorage,
                                OriginalFilename = file.FileName,
                                Name = trustedFileNameForFileStorage,
                                AlternateText = "default",
                                Description = "default",
                                Width = 500,
                                Height = 500
                            };
                            await mediaApi.AddMedia(media);
                        }
                        catch (IOException ex)
                        {
                            logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                                trustedFileNameForDisplay, ex.Message);
                            uploadResult.ErrorCode = 3;
                        }
                    }

                    filesProcessed++;
                }
                else
                {
                    logger.LogInformation("{FileName} not uploaded because the " +
                        "request exceeded the allowed {Count} of files (Err: 4)",
                        trustedFileNameForDisplay, maxAllowedFiles);
                    uploadResult.ErrorCode = 4;
                }

                uploadResults.Add(uploadResult);
            }

            return new CreatedResult(resourcePath, uploadResults);
        }
    }
}
