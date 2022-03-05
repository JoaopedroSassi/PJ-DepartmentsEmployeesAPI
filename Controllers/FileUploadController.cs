using DepartmentsCompanies.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace DepartmentsCompanies.Controllers
{
    [ApiController]
    [Route("upload")]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public int EmployeeId { get; set; }

        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("{id:int}")]
        public string Post([FromForm] FileUpload file, int id)
        {
            EmployeeId = id;
            try
            {
                if (file.files.Length <= 0)
                    return "Not uploaded | File length less or equal to 0";

                string path = _webHostEnvironment.WebRootPath + "\\Photos\\";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (FileStream fileStream = System.IO.File.Create(path + file.files.FileName))
                {
                    file.files.CopyTo(fileStream);
                    fileStream.Flush();
                    return "Uploaded";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
