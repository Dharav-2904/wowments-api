using System;
using System.Collections.Generic;

namespace wowments_api.Model
{
    public partial class UserRoles
    {
        public Guid UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
