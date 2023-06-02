using library_system.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library_system.Models
{
    public class QuestionDetailsResponse
    {
        [JsonProperty("items")]
        public List<Question> Items { get; set; }
    }
}