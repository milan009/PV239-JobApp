using System;

namespace JobApp.Models
{
    public class Contact : BasicObject
    {
        // parameters

        //TO DO: Obmedzit dlzku na 100 znakov
        public String Name { get; set; }

        //TO DO: Nech to je telefonne cislo
        public String Phone { get; set; }

        //TO DO: Nech to je mail
        public String Email { get; set; }

    }
}
