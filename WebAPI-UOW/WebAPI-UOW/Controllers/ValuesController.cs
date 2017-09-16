using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_UOW.Models.Services;

namespace WebAPI_UOW.Controllers {
    public class ValuesController : ApiController {
        private readonly IPersonService _personService;

        public ValuesController(IPersonService personService) {
            _personService = personService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> GetListPerson() {
            return Ok(await _personService.GetListPersion());
        }
    }
}