using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiRest.Client.Models;
using WebApiRest.Client.Services;
using WebApiRest.Shared;

namespace WebApiRest.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudientService _studientService;

        public HomeController(IStudientService studientService)
        {
            _studientService = studientService;
        }

        public async Task<IActionResult> Index()
        {
            List<StudientDTO> list = await _studientService.GetAllStudients();

            return View(list);
        }

        public async Task<IActionResult> Studient(int IdStudient)
        {
            StudientDTO studient = new StudientDTO();

            ViewBag.action = "Studient Details";

            if(IdStudient != 0) 
            {
                studient = await _studientService.GetStudient(IdStudient);

            }

            return View(studient);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(StudientDTO studient)
        {
            int? response = await _studientService.SaveHandle(studient);

            if(response != null) 
                return RedirectToAction("Index");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteStudient(int idStudient)
        {
            var response = await _studientService.DeleteStudient(idStudient);

            if (response)
                return RedirectToAction("Index");
            else
                return NoContent();
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