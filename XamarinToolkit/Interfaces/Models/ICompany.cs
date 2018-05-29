using System;

namespace XamarinToolkit.Interfaces.Models
{
    public interface ICompany
    {
        String Name { get; set; }
        Guid Id { get; set; }
    }
}