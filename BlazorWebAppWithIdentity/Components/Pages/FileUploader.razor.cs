using Business.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebAppWithIdentity.Components.Pages
{
    public partial class FileUploader : ComponentBase
    {
        [Inject]
        protected NavigationManager navigationManager { get; set; }
        [Parameter]
        public string SaveUrl { get; set; } = "api/MediaClient";
        private List<IBrowserFile> SelectedFiles { get; set; } = new();
        private string uploadStatus;
        private long maxFileSize = 1048576 * 4; // 4MB
        private int maxAllowedFiles = 3;
        private bool isLoading;

        //private async Task HandleFileSelected(InputFileChangeEventArgs e)
        //{
        //    isLoading = true;
        //    SelectedFiles.Clear();

        //    // Define the project root folder
        //    var projectRoot = Environment.ContentRootPath;
        //    var mediaFolder = Path.Combine(projectRoot, $"Medias/{Environment.EnvironmentName}/unsafe_uploads");

        //    foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
        //    {
        //        try
        //        {
        //            // Generate a unique name for the file
        //            var trustedFileName = Guid.NewGuid() + Path.GetExtension(file.Name);

        //            // Ensure the media folder exists
        //            if (!Directory.Exists(mediaFolder))
        //            {
        //                Directory.CreateDirectory(mediaFolder);
        //            }

        //            // Define the file's full path
        //            var filePath = Path.Combine(mediaFolder, trustedFileName);

        //            // Save the file
        //            await using FileStream fs = new(filePath, FileMode.Create);
        //            await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

        //            SelectedFiles.Add(file);

        //            // Log success
        //            Logger.LogInformation("Unsafe Filename: {UnsafeFilename} File saved: {Filename}", file.Name, trustedFileName);
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
        //            // Add a toast or notification for errors
        //        }
        //    }

        //    isLoading = false;
        //}

        //private async Task HandleSaveUrl(InputFileChangeEventArgs e)
        //{
        //    isLoading = true;
        //    var files = e.GetMultipleFiles(maxAllowedFiles);
        //    isLoading = false;
        //}

        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            isLoading = true;
            SelectedFiles.Clear();

            // Prepare the multipart form-data content for file upload
            var content = new MultipartFormDataContent();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                try
                {
                    // Add the file to the form content
                    var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                    content.Add(fileContent, "files", file.Name);

                    // Log success
                    Logger.LogInformation("Unsafe Filename: {UnsafeFilename} queued for upload", file.Name);
                }
                catch (Exception ex)
                {
                    Logger.LogError("Error preparing file: {Filename} Error: {Error}", file.Name, ex.Message);
                }
            }

            // Send the HTTP POST request to the server
            try
            {
                var url = navigationManager.BaseUri + SaveUrl;

                var response = await Http.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var uploadResults = await response.Content.ReadFromJsonAsync<List<UploadResultEventArgs>>();
                    Logger.LogInformation("Upload completed with {Count} results", uploadResults?.Count ?? 0);
                    // Handle success, e.g., notify user, update UI, etc.
                }
                else
                {
                    Logger.LogError("File upload failed with status code: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error during file upload: {Error}", ex.Message);
                // Handle network or server error
            }

            isLoading = false;
        }


    }
}
