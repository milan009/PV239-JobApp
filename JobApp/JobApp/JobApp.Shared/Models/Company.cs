using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("Company")]
    public class Company : BasicObject, ICompany
    {
        //TO DO: Obmedzit dlzku na 100 znakov
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
