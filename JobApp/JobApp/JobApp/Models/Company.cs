using System;

namespace JobApp.Models
{
    class Company : BasicObject
    {
        // parameters

        //TO DO: Obmedzit dlzku na 100 znakov
        public String Name { get; set; }

        public Contact Contact { get; set; }

        public Address Address { get; set; }

    }
}
