using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Models
{
    public class JobOffer : BasicObject
    {
        // parameters

        public Company Company { get; set; }

        public String Position { get; set; }

        //TO DO: mozme proste k interview priradit ID jobOffer
        public List<Interview> Interviews { get; set; }

        public int? OfferedPay { get; set; }

        public DateTime? CommencementDate { get; set; }

        //TO DO: Typ uvazku

        public String Note { get; set; }

    }
}
