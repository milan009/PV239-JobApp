using System;
using SQLite;

namespace JobApp.Models
{
    [Table("Interview")]
    public class Interview : BasicObject, IInterview
    {
        // parameters
        public Guid JobOfferId { get; set; }

        public DateTime Date { get; set; }

        public int Round
        {
            get; set;
        }
    }
}
