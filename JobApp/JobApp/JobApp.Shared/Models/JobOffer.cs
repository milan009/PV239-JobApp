using System;
using SQLite;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("JobOffer")]
    public class JobOffer : BasicObject, IJobOffer
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
