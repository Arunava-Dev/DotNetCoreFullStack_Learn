using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.Repositories.Implementations
{
    public class UtilityRepo : IUtilityRepo
    {
        private IWebHostEnvironment _env; // this service helps to enter wwwroot
        private IHttpContextAccessor _contextAccessor;
        // We need this service to retrive the scheme and Host
        //https://localhost:7283 scheme - https , Host - localhost:7283
        public UtilityRepo(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }
        // dbPath -  //https://localhost:7283/ContainerName/yuioi-ui980-opik.jpg
        public Task DeleteImage(string ContainerName, string dbPath)
        {
            if(string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(dbPath);
            var completePath = Path.Combine(dbPath, ContainerName, fileName);
            if (File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string ContainerName, IFormFile file, string dbPath)
        {
            await DeleteImage(ContainerName, dbPath);
            return await SaveImage(ContainerName, file);
        }
        //Guid.newguid() 
        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {   
            //Steps to getting the path where the file to be saved
            var extension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(_env.WebRootPath, ContainerName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, filename);

            //Steps for saving the file
            using (var memoryStreem = new MemoryStream())
            {
                await file.CopyToAsync(memoryStreem); // converted to bites in memoryStram
                var content = memoryStreem.ToArray(); // converted to Array
                await File.WriteAllBytesAsync(filePath, content); // content will be copied in the folder

            }
            //To store the file in DB 

            var basePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}"; //https://localhost:7283
            var completePath = Path.Combine(basePath, ContainerName, filename).Replace("\\", "/");

            return completePath;
        }
    }
}
