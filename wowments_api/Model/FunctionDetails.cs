using System;
using System.Collections.Generic;

namespace wowments_api.Model
{
    public partial class FunctionDetails
    {
        public Guid Id { get; set; }
        public Guid FunctionId { get; set; }
        public DateTime FunctionDate { get; set; }

        public virtual Functions Function { get; set; }
    }
}
