using System;
using SQLite;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("Interview")]
    public class Interview : BasicObject, IInterview, IInterview
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
