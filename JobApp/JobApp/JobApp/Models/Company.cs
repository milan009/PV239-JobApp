using System;
using SQLite;

namespace JobApp.Models
{
    [Table("Company")]
    public class Company : BasicObject
    {
        //TO DO: Obmedzit dlzku na 100 znakov
        public String Name { get; set; }
    }
}
