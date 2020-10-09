using System;
using System.Collections.Generic;

namespace wowments_api.Model
{
    public partial class Functions
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Guid? ParentId { get; set; }
    }
}
