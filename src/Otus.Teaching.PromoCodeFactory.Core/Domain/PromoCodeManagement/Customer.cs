using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // // //

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer
        :BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FullName => $"{FirstName} {LastName}";

        [StringLength(50)]
        public string Email { get; set; }

        public virtual ICollection<CustomerPreference> Preferences { get; set; }

        public virtual ICollection<PromoCode> PromoCodes { get; set; } // // //
    }
}