using System;

namespace JobApp.Models
{
    class Address : BasicObject
    {
        // parameters

        //TO DO: Obmedzit dlzku na 50 znakov
        public String Street { get; set; }          //pridavam random koment, aby som videl, ako sa bude spravat visual studio

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
