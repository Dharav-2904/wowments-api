using System;
using System.Collections.Generic;

namespace wowments_api.Model
{
    public partial class Roles
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
