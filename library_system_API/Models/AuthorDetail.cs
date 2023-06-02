using System;
using System.Collections.Generic;

namespace library_system_API.Models;

public partial class AuthorDetail
{
    public int Id { get; set; }

    public string? AuthorName { get; set; }

    public int? RegisterNumber { get; set; }

    public virtual ICollection<MasterBookInformation> MasterBookInformations { get; set; } = new List<MasterBookInformation>();
}
