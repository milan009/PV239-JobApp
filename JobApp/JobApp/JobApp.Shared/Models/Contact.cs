using System;
using System.Collections.Generic;
using JobApp.Shared.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace JobApp.Shared.Models
{
    [Table("Contact")]
    public class Contact : BasicObject, IContact
    {
        public String Name { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        [OneToMany(ReadOnly = true)]
        public List<JobOffer> ContactFor { get; set; }
    }
}
