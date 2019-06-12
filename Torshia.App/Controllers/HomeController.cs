using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using System.Linq;
using Torshia.App.ViewModels;

namespace Torshia.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public ActionResult IndexSlash()
        {
            return Index();
        }
        public ActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.View(new UserHomeViewModel { Username = this.User.Username, Role = this.User.Roles.FirstOrDefault() }, "Home");
            }

            return this.View();
        }
    }
}
