using System;
using JobApp.Shared.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace JobApp.Shared.Models
{
    [Table("Address")]
    public class Address : BasicObject, IAddress
    {
        [ForeignKey(typeof(Company))]
        public Guid CompanyId { get; set; }

        public String Street { get; set; }

        public String Number { get; set; }

        public String City { get; set; }

        public String PostCode { get; set; }

        public String Country { get; set; }

        [OneToOne(ReadOnly = true)]
        public Company Company {get; set; }

        [Ignore]
        public String AddressInfoCalculated =>
            $"{this.Street} {this.Number}, {this.PostCode} {this.City}, {this.Country}";
    }
}
