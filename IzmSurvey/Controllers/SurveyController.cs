using Microsoft.AspNetCore.Mvc;

namespace IzmSurvey.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
