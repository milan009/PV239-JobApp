using System;

namespace JobApp.Shared.Interfaces.Models
{
    public interface IAddress
    {
        Guid CompanyId { get; set; }
        Guid Id { get; set; }

        String Street { get; set; }
        String Number { get; set; }
        String City { get; set; }
        String PostCode { get; set; }
        String Country { get; set; }
        String AddressInfoCalculated { get; }
    }
}