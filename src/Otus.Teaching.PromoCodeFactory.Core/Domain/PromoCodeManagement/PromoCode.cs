using System;
using System.Runtime;
using System.ComponentModel.DataAnnotations;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode
        : BaseEntity
    {
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [StringLength(50)]
        public string PartnerName { get; set; }

        public virtual Employee PartnerManager { get; set; }

        public virtual Preference Preference { get; set; }
    }
}