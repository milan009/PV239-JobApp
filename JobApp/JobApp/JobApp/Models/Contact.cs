using System;
using SQLite;

namespace JobApp.Models
{
    [Table("Contact")]
    public class Contact : BasicObject
    {
        // parameters

        public Guid CompanyId { get; set; }

        //TO DO: Obmedzit dlzku na 100 znakov
        public String Name { get; set; }

        //TO DO: Nech to je telefonne cislo
        public String Phone { get; set; }

        //TO DO: Nech to je mail
        public String Email { get; set; }

    }
}
