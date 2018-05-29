using System;

namespace XamarinToolkit.Interfaces.Models
{
    public interface IInterview
    {
        Guid JobOfferId { get; set; }
        DateTime Date { get; set; }
        int Round { get; set; }
        Guid Id { get; set; }
    }
}