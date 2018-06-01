using System;

namespace JobApp.Shared.Interfaces.Models
{
    public interface ICompany
    {
        Guid Id { get; set; }
        String Name { get; set; }
    }
}