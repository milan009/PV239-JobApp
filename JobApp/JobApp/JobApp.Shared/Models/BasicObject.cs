using SQLite;
using System;

namespace JobApp.Shared.Models
{
    public class BasicObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    }
}
