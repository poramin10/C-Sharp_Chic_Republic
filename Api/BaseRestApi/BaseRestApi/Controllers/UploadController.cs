using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BaseRestApi.DTO;
using BaseRestApi.Utility.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        private readonly ILogger<UploadController> _logger;
        private ITrace Trace { get; }

        private IWebHostEnvironment environment;

        public UploadController(ILogger<UploadController> logger, ITrace Trace,IWebHostEnvironment environment)
        {
            _logger = logger;
            this.Trace = Trace;
            // this.environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<Result<String>> UploadProfile()
        {
            Result<string> result = new Result<string>(Trace);
            try
            {
                // environment.roo
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                // var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                   
                    var fileName = $"{DateTime.Now.ToFileTime()}.png";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    result.Success = true;
                    result.Data = dbPath;
                    result.Message = "Success";
                    return result;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Failed";
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = "Failed";
                return result;
                // return StatusCode(500, $"Internal Server Error: {e}");
            }

        }
    }
}