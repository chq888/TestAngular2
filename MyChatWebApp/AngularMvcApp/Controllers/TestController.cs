using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularMvcApp.Controllers
{

    public class TestController : Controller
    {

        public TestController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ContentResult AjaxMethod(string name)
        {
            var result = new UserData()
            {
                LoginName = this.User.Identity!.Name!
            };

            string currentDateTime = string.Format("Hello {0}.\nCurrent DateTime: {1}", name, DateTime.Now.ToString());
            return Content(currentDateTime);
        }

    }

}