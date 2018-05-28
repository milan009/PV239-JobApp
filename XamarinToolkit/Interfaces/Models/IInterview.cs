using System;

namespace JobApp.Models
{
    public interface IInterview
    {
        DateTime Date { get; set; }
        int Round { get; set; }
    }
}