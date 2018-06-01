using System;

namespace JobApp.Shared.Interfaces.Models
{
    public interface IJobOffer
    {
        Guid Id { get; set; }
        Guid CompanyId { get; set; }
        String Position { get; set; }
        String Note { get; set; }

        int? OfferedPay { get; set; }
        DateTime? CommencementDate { get; set; }
    }
}