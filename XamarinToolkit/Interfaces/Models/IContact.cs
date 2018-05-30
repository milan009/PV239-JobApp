using System;

namespace XamarinToolkit.Interfaces.Models
{
    public interface IContact
    {
        String Name { get; set; }
        String Phone { get; set; }
        String Email { get; set; }
        Guid Id { get; set; }
    }
}