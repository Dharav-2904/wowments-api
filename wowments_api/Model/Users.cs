using System;
using System.Collections.Generic;

namespace wowments_api.Model
{
    public partial class Users
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsGuest { get; set; }
        public string Mobile { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
