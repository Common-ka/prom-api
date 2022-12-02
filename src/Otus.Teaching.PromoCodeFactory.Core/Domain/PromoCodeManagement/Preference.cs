using System;
using System.ComponentModel.DataAnnotations;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Preference
        :BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}