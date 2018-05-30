﻿using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("Address")]
    public class Address : BasicObject, IAddress
    {
        // parameters
        [ForeignKey(typeof(Company))]
        public Guid CompanyId { get; set; }

        //TO DO: Obmedzit dlzku na 50 znakov
        public String Street { get; set; }

        //TO DO: Obmedzit dlzku na 10 znakov
        public String Number { get; set; }

        //TO DO: Obmedzit dlzku na 50 znakov
        public String City { get; set; }

        //TO DO: Obmedzit dlzku na 5 znakov
        public String PostCode { get; set; }

        //TO DO: Obmedzit dlzku na 50 znakov
        public String Country { get; set; }

        [OneToOne(ReadOnly = true)]
        public Company Company {get; set; }

        [Ignore]
        public String AddressInfoCalculated =>
            $"{this.Street} {this.Number}, {this.PostCode} {this.City}, {this.Country}";
    }
}
