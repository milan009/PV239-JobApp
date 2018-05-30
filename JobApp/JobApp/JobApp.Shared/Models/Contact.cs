using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("Contact")]
    public class Contact : BasicObject, IContact
    {
        //TO DO: Obmedzit dlzku na 100 znakov
        public String Name { get; set; }

        //TO DO: Nech to je telefonne cislo
        public String Phone { get; set; }

        //TO DO: Nech to je mail
        public String Email { get; set; }

        [OneToMany(ReadOnly = true)]
        public List<JobOffer> ContactFor { get; set; }
    }
}
