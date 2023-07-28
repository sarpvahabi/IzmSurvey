using IzmSurvey.Areas.Admin.ViewModels;
using IzmSurvey.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IzmSurvey.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyResponseController : Controller
    {
        private readonly IzmSurveyDbContext _izmSurveyDbContext;

        public SurveyResponseController(IzmSurveyDbContext izmSurveyDbContext)
        {
            _izmSurveyDbContext = izmSurveyDbContext;
        }

        [HttpGet("Admin/SurveyResponses/{Id:guid}")]
        public IActionResult Index(Guid id)
        {
            CustomerSurvey? customerSurvey = _izmSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);

            List<CustomerSurveyResponse>? customerSurveyResponse = _izmSurveyDbContext.CustomerSurveyResponses
                .Include(x => x.Answers)
                .Where(x => x.SurveyId == id).ToList();

            SurveyResponseViewModel surveyResponseViewModel = new SurveyResponseViewModel(
                customerSurvey,
                customerSurveyResponse
                );
            return View(surveyResponseViewModel);
        }
    }
}
