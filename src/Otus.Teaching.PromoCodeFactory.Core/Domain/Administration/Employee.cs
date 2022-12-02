using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // // //

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.Administration
{
    public class Employee
        : BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FullName => $"{FirstName} {LastName}";

        [StringLength(50)]
        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}