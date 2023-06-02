using System;
using System.Collections.Generic;

namespace library_system_API.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public int? MainCategoryId { get; set; }

    public string? SubCategoryName { get; set; }

    public virtual CategoryDetail? MainCategory { get; set; }

    public virtual ICollection<MasterBookInformation> MasterBookInformations { get; set; } = new List<MasterBookInformation>();
}
