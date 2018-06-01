using System;
using System.Collections.Generic;
using JobApp.Shared.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace JobApp.Shared.Models
{
    [Table("Company")]
    public class Company : BasicObject, ICompany
    {
        public String Name { get; set; }

        // Navigation properties
        [OneToMany(ReadOnly = true)]
        public List<JobOffer> JobOffers { get; set; }

        [OneToMany(ReadOnly = true)]
        public List<Contact> Contacts { get; set; }

        [OneToOne(ReadOnly = true)]
        public Address Address { get; set; }
    }
}
