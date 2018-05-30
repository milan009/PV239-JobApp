using System;
using JobApp.Shared.Models;

namespace JobApp
{
    public static class MockData
    {
        public static Guid[] CompanyGuids =
        {
            Guid.Parse("CDADA936-9C83-4067-9A59-772EC83E1DB0"),
            Guid.Parse("1E521CE5-2687-41FF-8D47-45DE24A94D46"),
        };

        public static Guid[] ContactGuids =
        {
            Guid.Parse("CDADA936-9C83-4067-9A59-772EC83E1DBB"),
            Guid.Parse("1E521CE5-2687-41FF-8D47-45DE29A94D46"),
            Guid.Parse("E169494E-1B91-4E53-AEA2-B4E1555B5B9C"),
        };

        public static Guid[] InterviewGuids =
        {
            Guid.Parse("0DADA936-9C83-4067-9A59-772EC83E1DB0"),
            Guid.Parse("0E521CE5-2687-41FF-8D47-45DE24A94D46"),
            Guid.Parse("0169494E-1B91-4053-AEA2-B4E1555B5B9C"),
        };

        public static Guid[] JobOfferGuids =
        {
            Guid.Parse("00ADA936-9C83-4067-9A59-772EC83E1DB0"),
            Guid.Parse("00521CE5-2687-41FF-8D47-45DE24A94D46"),
        };

        public static Guid[] AddressGuids =
        {
            Guid.Parse("0D0DA936-9C83-4067-9A59-772EC83E1DB0"),
            Guid.Parse("0E021CE5-2687-41FF-8D47-45DE24A94D46"),
        };

        public static Contact[] Contacts =
        {
            new Contact
            {
                Id = ContactGuids[0],
                CompanyId = CompanyGuids[0],
                Email = "SamMolek@Bloh.Glog",
                Name = "Sam Molek",
                Phone = "157201652"
            },
            new Contact
            {
                Id = ContactGuids[1],
                CompanyId = CompanyGuids[0],
                Email = "WendyWolowitz@Wloh.Wlah",
                Name = "Wendy Wolowitz",
                Phone = "778778822"
            },
            new Contact
            {
                Id = ContactGuids[2],
                CompanyId = CompanyGuids[1],
                Email = "Johnny@JohnnySolver.com",
                Name = "JohnnySolever",
                Phone = "000000000"
            },
        };

        public static Interview[] Interviews =
        {
            new Interview
            {
                Date = DateTime.Now + TimeSpan.FromDays(1),
                Id = InterviewGuids[0],
                Round = 1,
                JobOfferId = JobOfferGuids[0]
            },

            new Interview
            {
                Date = DateTime.Now + TimeSpan.FromDays(2),
                Id = InterviewGuids[1],
                Round = 2,
                JobOfferId = JobOfferGuids[0]
            },

            new Interview
            {
                Date = DateTime.Now + TimeSpan.FromDays(3),
                Id = InterviewGuids[2],
                Round = 1,
                JobOfferId = JobOfferGuids[1]
            },
        };

        public static Address[] Addresses =
        {
            new Address
            {
                City = "Brno",
                CompanyId = CompanyGuids[0],
                Country = "Czech Republic",
                Id = AddressGuids[0],
                Number = "4",
                Street = "Františkánská",
                PostCode = "12345",
            },
            new Address
            {
                City = "Prague",
                CompanyId = CompanyGuids[1],
                Country = "Czech Republic",
                Id = AddressGuids[1],
                Number = "8",
                Street = "Vinohrady",
                PostCode = "11111",
            }
        };

        public static JobOffer[] JobOffers =
        {
            new JobOffer
            {
                Id = JobOfferGuids[0],
                CommencementDate = DateTime.Today + TimeSpan.FromDays(30),
                CompanyId = CompanyGuids[0],
                Note = "Do you like cleaning dishes? In that case, we want YOU in our company!",
                Position = "Dish washer",
                OfferedPay = 12000,
            },
            new JobOffer
            {
                Id = JobOfferGuids[1],
                CommencementDate = DateTime.Today + TimeSpan.FromDays(30),
                CompanyId = CompanyGuids[1],
                Note = "Youe task will be mostly focused on taking care of our cars",
                Position = "Car cleaner",
                OfferedPay = 22000,
            },
        };

        public static Company[] Companies =
        {
            new Company
            {
                Id = CompanyGuids[0],
                Name = "The bad company",
            },

            new Company
            {
                Id = CompanyGuids[1],
                Name = "One way better company!",
            },
        };
    }
}