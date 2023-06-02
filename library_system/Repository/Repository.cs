using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library_system.Models;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Web.Services.Description;

namespace library_system.Repository
{
    public class Repository
    {
        private library_systemEntities2 db;
        private const string StackOverflowApiUrl = "https://api.stackexchange.com/2.3";

        public List<SelectallBooks_Result> RetriveDataFromStordProcedure()
        {
            using (db = new library_systemEntities2())
            {
                List<SelectallBooks_Result> lib_data = db.SelectallBooks().ToList();
                CommonDataMapper mapper = new CommonDataMapper();
                var data = mapper.MainBookDetailsMapper(lib_data);
                return data;
            }
        }

        public List<master_book_information> RetriveDataFromEFModel()
        {
            using (db = new library_systemEntities2())
            {
                List<master_book_information> booksData = (from x in db.master_book_information select x ).ToList();
                CommonDataMapper mapper = new CommonDataMapper();
                var data = mapper.MainBookDetailsEFMapper(booksData);
                return data;
            }
        }

        public List<SubCategoryModel> SubCategoryById(int id)
        {
            using (db = new library_systemEntities2())
            {
                CommonDataMapper mapper = new CommonDataMapper();
                List<SubCategoryModel> subcategory = mapper.SubCategoryMapper((from x in db.sub_category where x.main_category_id == id select x).ToList());

                return subcategory;
            }
        }

        public List<category_details> GetAllCategoryDetails()
        {
            using (db = new library_systemEntities2())
            {
                var all_category = (from x in db.category_details select x).ToList();
                return all_category;
            }
        }

        

        public async Task<List<Question>> GetQuestions()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.stackexchange.com/2.3/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow");


                if (response.IsSuccessStatusCode)
                {

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (GZipStream gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(gzipStream))
                            {
                                QuestionsResponse questionsResponse = JsonConvert.DeserializeObject<QuestionsResponse>(await reader.ReadToEndAsync());
                                return questionsResponse.Items;
                            }
                        }
                    }
                }

                // Handle API error
                throw new Exception($"Failed to retrieve questions. Error: {response}");
            }
        }

        public async Task<Question> GetQuestionDetails(int questionId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{StackOverflowApiUrl}/questions/{questionId}?order=desc&sort=activity&site=stackoverflow");
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (GZipStream gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(gzipStream))
                            {
                                QuestionDetailsResponse questionResponse = JsonConvert.DeserializeObject<QuestionDetailsResponse>(await reader.ReadToEndAsync());
                                return questionResponse.Items.FirstOrDefault();
                            }
                        }
                    }

                }

                // Handle API error
                throw new Exception($"Failed to retrieve question details. Error: {responseBody}");
            }
        }

        
    }
}