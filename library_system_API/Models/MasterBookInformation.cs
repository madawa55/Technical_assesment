using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace library_system_API.Models;

public partial class MasterBookInformation
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 6)]
    public string Isbn { get; set; } = null!;

    public string? BookName { get; set; }

    public int? CategoryId { get; set; }

    public int? SubCategoryId { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? PublishedYear { get; set; }

    public virtual AuthorDetail? Author { get; set; }

    public virtual CategoryDetail IdNavigation { get; set; } = null!;

    public virtual SubCategory? SubCategory { get; set; }
}
