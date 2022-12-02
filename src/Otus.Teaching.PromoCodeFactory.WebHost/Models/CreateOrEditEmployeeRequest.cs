using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class CreateOrEditEmployeeRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; } 

        public int AppliedPromocodesCount { get; set; }
    }
}