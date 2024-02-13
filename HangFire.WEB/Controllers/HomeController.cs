using HangFire.WEB.BackgroundJob;
using HangFire.WEB.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace HangFire.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult SignUp()
        {
            // new user signup
            // new userID "1234"
            FireAndForgetJobs.EmailSendToUserJob("1234", "Welcome to our Website!!!!!");
            return View();
        }

        public IActionResult PictureSave()
        {
            BackgroundJob.RecurringJob.ReportingJob();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName = String.Empty;

            if(picture != null &&picture.Length>0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }


                string jobId = BackgroundJob.DelayedJobs.AddWatermarkJob(newFileName,"www.mysite.com");

                BackgroundJob.ContinuationsJob.WriteWaterMarkStatus(jobId,newFileName);
            }

            return View();
        }
    }
}
