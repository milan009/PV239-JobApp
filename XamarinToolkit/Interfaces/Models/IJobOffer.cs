using System;

namespace XamarinToolkit.Interfaces.Models
{
    public interface IJobOffer
    {
        Guid CompanyId { get; set; }
        String Position { get; set; }
        int? OfferedPay { get; set; }
        DateTime? CommencementDate { get; set; }
        String Note { get; set; }
        Guid Id { get; set; }
    }
}