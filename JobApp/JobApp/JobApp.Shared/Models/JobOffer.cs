using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("JobOffer")]
    public class JobOffer : BasicObject, IJobOffer
    {
        // parameters
        [ForeignKey(typeof(Company))]
        public Guid CompanyId { get; set; }

        [ForeignKey(typeof(Contact))]
        public Guid ContactId { get; set; }

        public String Position { get; set; }

        public int? OfferedPay { get; set; }

        public DateTime? CommencementDate { get; set; }

        //TO DO: Typ uvazku

        public String Note { get; set; }

        [OneToMany(ReadOnly = true)]
        public List<Interview> Interviews { get; set; }

        [ManyToOne(ReadOnly = true)]
        public Company Company { get; set; }

        [ManyToOne(ReadOnly = true)]
        public Contact Contact { get; set; }
    }
}
