using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using library_system.Models;
using library_system.Repository;
using Newtonsoft.Json;

namespace library_system.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult DataViewEF()
        {

            Repository.Repository repo = new Repository.Repository();
            var data = repo.RetriveDataFromEFModel();
            return View(data);
        }

        public ActionResult DataViewSP()
        {

            Repository.Repository repo = new Repository.Repository();
            var data = repo.RetriveDataFromStordProcedure();
            return View(data);
        }


        public ActionResult DropDownPage()
        {
            Repository.Repository repo = new Repository.Repository();
            var data = repo.GetAllCategoryDetails();
            ViewBag.category_data = new SelectList(repo.GetAllCategoryDetails(), "id", "category_name");
            return View(data);
        }

        public string GetSubcategory(int id)
        {
            Repository.Repository repo = new Repository.Repository();
            var data = repo.SubCategoryById(id);
            return JsonConvert.SerializeObject(data);
        }

        public async Task<ActionResult> ManageStackExchangeQiz()
        {
            Repository.Repository repo = new Repository.Repository();
            List<Question> questions = await repo.GetQuestions();
            return View(questions);
        }

        public ActionResult FunctionwithVanillaJS()
        {
            Repository.Repository repo = new Repository.Repository();
            var data = repo.GetAllCategoryDetails();
            ViewBag.category_data = data;
            return View(data);
        }

        public async Task<ActionResult> Details(int questionId)
        {
            Repository.Repository repo = new Repository.Repository();
            Question question = await repo.GetQuestionDetails(questionId);
            return View( question);
        }



    }

}