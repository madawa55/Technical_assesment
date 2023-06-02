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
        private const string StackOverflowApiUrl = "https://api.stackexchange.com/2.3";
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
            List<Question> questions = await GetQuestions();
            return View("QuestionsList", questions);
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
            Question question = await GetQuestionDetails(questionId);
            return View("QuestionDetails", question);
        }

        private async Task<List<Question>> GetQuestions()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.stackexchange.com/2.3/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow");
                

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return null;
                }

                // Handle API error
                throw new Exception($"Failed to retrieve questions. Error: {response}");
            }
        }

        private async Task<Question> GetQuestionDetails(int questionId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{StackOverflowApiUrl}/questions/{questionId}?order=desc&sort=activity&site=stackoverflow");
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    QuestionDetailsResponse questionResponse = JsonConvert.DeserializeObject<QuestionDetailsResponse>(responseBody);
                    return questionResponse.Items.FirstOrDefault();
                }

                // Handle API error
                throw new Exception($"Failed to retrieve question details. Error: {responseBody}");
            }
        }


    }

    public class QuestionsResponse
    {
        [JsonProperty("items")]
        public List<Question> Items { get; set; }
    }

    public class QuestionDetailsResponse
    {
        [JsonProperty("items")]
        public List<Question> Items { get; set; }
    }

    public class Question
    {
        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        
    }
}