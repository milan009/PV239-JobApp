using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("Interview")]
    public class Interview : BasicObject, IInterview
    {
        [ForeignKey(typeof(JobOffer))]
        public Guid JobOfferId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int Round { get; set; }

        [ManyToOne(ReadOnly = true)]
        public JobOffer JobOffer { get; set; }
    }
}
