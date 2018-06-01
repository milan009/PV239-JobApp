using System;

namespace JobApp.Shared.Interfaces.Models
{
    public interface IContact
    {
        Guid Id { get; set; }

        String Name { get; set; }
        String Phone { get; set; }
        String Email { get; set; }
    }
}