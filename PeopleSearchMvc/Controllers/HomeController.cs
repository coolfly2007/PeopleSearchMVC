using System.IO;
using System.Linq;
using System.Web.Mvc;
using PeopleSearchMvc.Data;
using PeopleSearchMvc.Manager;
using PeopleSearchMvc.Models;

namespace PeopleSearchMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeopleSearchManager _peopleSearchManager = new PeopleSearchManager(new PeopleRespository());

        public ActionResult Index()
        {
            var model = _peopleSearchManager.GetPersonSearchResult("");
            return View(new PeopleListModel {PeopleList = model.ToList()});
        }

        [HttpPost]
        public JsonResult SearchPeople(SearchStringModel searchStringModel)
        {
            //simulate a delayed response
            System.Threading.Thread.Sleep(3000);
            var model = _peopleSearchManager.GetPersonSearchResult(searchStringModel.SearchString);
            return Json(new {viewResult = RenderPartialViewToString (this, "PeopleList", new PeopleListModel { PeopleList = model.ToList()})});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /***
         * This is a third party method from stackOverflow to convert a partial view to string format in order to return as a JasonResult type.
         * https://stackoverflow.com/questions/15588488/asp-net-mvc-render-partial-view-to-a-string-to-return-with-json
        ***/
        public static string RenderPartialViewToString(Controller thisController, string viewName, object model)
        {
            // assign the model of the controller from which this method was called to the instance of the passed controller (a new instance, by the way)
            thisController.ViewData.Model = model;

            // initialize a string builder
            using (StringWriter sw = new StringWriter())
            {
                // find and load the view or partial view, pass it through the controller factory
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(thisController.ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(thisController.ControllerContext, viewResult.View, thisController.ViewData, thisController.TempData, sw);

                // render it
                viewResult.View.Render(viewContext, sw);

                //return the razorized view/partial-view as a string
                return sw.ToString();
            }
        }
    }
}