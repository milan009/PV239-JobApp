using System;
using SQLite;

namespace JobApp.Models
{
    [Table("Interview")]
    public class Interview : BasicObject, IInterview
    {
        // parameters

        public DateTime Date { get; set; }

        public int Round
        {
            get; set;

        }
    }
}
