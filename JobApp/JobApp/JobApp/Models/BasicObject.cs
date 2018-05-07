using SQLite;
using System;

namespace JobApp.Models
{
    public class BasicObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    }
}
