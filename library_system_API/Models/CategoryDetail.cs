using System;
using System.Collections.Generic;

namespace library_system_API.Models;

public partial class CategoryDetail
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual MasterBookInformation? MasterBookInformation { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
