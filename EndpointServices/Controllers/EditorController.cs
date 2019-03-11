using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndpointServices.Controllers
{
    public class EditorController : Controller
    {
        IHostingEnvironment hostingEnvironment;
        public EditorController(IHostingEnvironment hostingEnvironment)
        {

            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("api/editor-image-upload")]
        public async Task<IActionResult> Index(IFormFile File)
        {
            string basePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            var uploads = Path.Combine(this.hostingEnvironment.WebRootPath, "Images");
            string filePath = "";
            string fileName = "";
            if (File.Length > 0)
            {
                fileName = Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(File.FileName);

                filePath = Path.Combine(uploads, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                }
            }

            return Json(new { imageUrl = $"{basePath}/images/{fileName}" });
        }
    }
}