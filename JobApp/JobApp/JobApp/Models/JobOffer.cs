using System;
using System.Collections.Generic;
using SQLite;

namespace JobApp.Models
{
    [Table("JobOffer")]
    public class JobOffer : BasicObject
    {
        // parameters

        public Guid CompanyId { get; set; }

        public String Position { get; set; }

        public int? OfferedPay { get; set; }

        public DateTime? CommencementDate { get; set; }

        //TO DO: Typ uvazku

        public String Note { get; set; }
    }
}
