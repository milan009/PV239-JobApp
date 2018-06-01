using System;
using System.Collections.Generic;
using JobApp.Shared.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;

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

        public bool Saved { get; set; } = false;

        public String Note { get; set; }

        [OneToMany(ReadOnly = true)]
        public List<Interview> Interviews { get; set; }

        [ManyToOne(ReadOnly = true)]
        public Company Company { get; set; }

        [ManyToOne(ReadOnly = true)]
        public Contact Contact { get; set; }
    }
}
