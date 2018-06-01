using System;

namespace JobApp.Shared.Interfaces.Models
{
    public interface IInterview
    {
        Guid Id { get; set; }
        Guid JobOfferId { get; set; }

        DateTime Date { get; set; }
        int Round { get; set; }
    }
}