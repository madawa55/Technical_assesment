﻿namespace library_system_API.Models
{
    public class MasterBookinfoRequest
    {
        public string? Isbn { get; set; }

        public string? BookName { get; set; }

        public int? CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public int? AuthorId { get; set; }

        public DateTime? PublishedYear { get; set; }
    }
}
