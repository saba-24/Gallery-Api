using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gallery_Api.Models;
using Gallery_Api.PublicClasses;
using NuGet.Protocol;


namespace Gallery_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoApisController : ControllerBase
    {

		private readonly string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
		
        [HttpPost] 
        public ActionResult UploadFile(IFormFile file)
        {
            return Ok(new UploadHandler().Upload(file));
        }

        [HttpGet]
        public ActionResult GetImages()
        {
            List<string> Images = Directory.GetFiles(rootPath).Select(Path.GetFileName).ToList(); 
            return Ok(Images);
        }

    }
}
