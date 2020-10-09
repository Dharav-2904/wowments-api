using System;
using System.Collections.Generic;

namespace wowments_api.Model
{
    public partial class Passwords
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
