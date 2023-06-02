using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library_system.Models
{
    public class Question
    {
        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("answer_count")]
        public string AnswerCount { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }


    }
}