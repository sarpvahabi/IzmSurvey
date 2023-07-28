using IzmSurvey.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IzmSurvey.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyController : Controller
    {
        private readonly IzmSurveyDbContext _globomanticsSurveyDbContext;

        public SurveyController(IzmSurveyDbContext globomanticsSurveyDbContext)
        {
            _globomanticsSurveyDbContext = globomanticsSurveyDbContext;
        }

        [HttpGet("Admin/Surveys")]
        public IActionResult Index()
        {
            return View(_globomanticsSurveyDbContext.CustomerSurveys.ToList());
        }

        [HttpGet("Admin/Survey/{Id:guid}")]
        public IActionResult Survey(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);
            return View(customerSurvey);
        }
    }
}
