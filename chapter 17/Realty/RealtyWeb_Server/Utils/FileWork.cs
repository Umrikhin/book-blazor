﻿using Microsoft.AspNetCore.Components.Forms;
using RealtyWeb_Server.Utils.IService;

namespace RealtyWeb_Server.Utils
{

    public class FileWork : IFileWork
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileWork(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteFile(string filePath)
        {
            var file = Path.GetFileName(filePath);
            var fullFile = Path.Combine(_webHostEnvironment.WebRootPath, "images", "houses", file);
            if (File.Exists(fullFile))
            {
                File.Delete(fullFile);
                return true;
            }
            return false;
        }

        public string RenameFile(string filePath)
        {
            var file = Path.GetFileName(filePath);
            var fullFile = Path.Combine(_webHostEnvironment.WebRootPath, "images", "houses", file);
            string fileTarget = Path.GetFileName(file).Replace("temp_", "house_");
            string fullFileTarget = Path.Combine(_webHostEnvironment.WebRootPath, "images", "houses", fileTarget);
            File.Copy(fullFile, fullFileTarget, true);
            return $"images/houses/{fileTarget}";
        }

        public bool CrearTemp()
        {
            try
            {
                var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "houses");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                DirectoryInfo dir = new DirectoryInfo(folderPath);
                var files = dir.GetFiles().Where(x => x.Name.StartsWith("temp_") && x.LastWriteTime < DateTime.Now.AddDays(-1));
                foreach (var fileItem in files)
                {
                    fileItem.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new FileInfo(file.Name);
            long maxSize = 102400; //100 КБ - макс. размер картинки
            var fileName = $"temp_{Guid.NewGuid() + fileInfo.Extension}";
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "houses");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var filePath = Path.Combine(folderPath, fileName);
            await using FileStream fs = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream(maxSize).CopyToAsync(fs);
            var fullPath = $"images/houses/{fileName}";
            return fullPath;
        }
    }
}
