using System.Web.Mvc;
using WebAPI_UOW.Models.Services;

namespace WebAPI_UOW.Controllers {
    public class HomeController : Controller {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService) {
            _personService = personService;
        }

        public ActionResult Index() {
            var list = _personService.GetListPersion();
            ViewBag.Title = "Home Page";
            return View(list);
        }
    }
}