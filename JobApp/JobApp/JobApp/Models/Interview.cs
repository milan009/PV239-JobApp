using System;

namespace JobApp.Models
{
    public class Interview : BasicObject
    {
        // parameters

        public DateTime Date { get; set; }

        public int Round
        {
            get; set;

        }
    }
}
