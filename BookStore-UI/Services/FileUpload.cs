using BlazorInputFile;
using BookStore_UI.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_UI.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _env;

        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void RemoveFile(string picName)
        {
            var path = $"{_env.WebRootPath}\\uploads\\{picName}";
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task UploadFile(IFileListEntry file, MemoryStream msFile, string picName)
        {
            try
            {
                await file.Data.CopyToAsync(msFile);

                var path = $"{_env.WebRootPath}\\uploads\\{picName}";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    msFile.WriteTo(fs);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
