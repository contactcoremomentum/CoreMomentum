using CoreMomentum.Web.Models;
using CoreMomentum.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreMomentum.Web.Views.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _StudentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _StudentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var userName = HttpContext.Session.GetString("userEmail");

            if (userName != null) {
                ResponseDto? response = await _StudentService.GetStudentByEmailAsync(userName);
                if (response.IsSuccess == false)
                {
                    return RedirectToAction("Upsert", "Student", 0);
                }
            }
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
    }
}