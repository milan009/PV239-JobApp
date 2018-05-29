﻿using System;
using SQLite;

namespace JobApp.Models
{
    [Table("Address")]
    public class Address : BasicObject
    {
        // parameters

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

        public String AddressInfoCalculated =>
            $"{this.Street} {this.Number}, {this.PostCode} {this.City}, {this.Country}";
    }
}
