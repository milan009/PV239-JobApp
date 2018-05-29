using System;
using SQLite;
using XamarinToolkit.Interfaces.Models;

namespace JobApp.Shared.Models
{
    [Table("Company")]
    public class Company : BasicObject, ICompany
    {
        //TO DO: Obmedzit dlzku na 100 znakov
        public String Name { get; set; }
    }
}
