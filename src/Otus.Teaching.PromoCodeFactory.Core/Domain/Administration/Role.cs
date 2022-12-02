using System;
using System.ComponentModel.DataAnnotations; // // //

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.Administration
{
    public class Role
        : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}