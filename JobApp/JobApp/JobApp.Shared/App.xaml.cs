using System;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.Services;
using JobApp.Shared.Views;
using SQLite;
using Xamarin.Forms;
using XamarinToolkit.Interfaces.Storage;

namespace JobApp
{
	public partial class App : Application
	{
	    public static Guid[] CompanyGuids =
	    {
	        Guid.Parse("CDADA936-9C83-4067-9A59-772EC83E1DB0"),
	        Guid.Parse("1E521CE5-2687-41FF-8D47-45DE24A94D46"),
	        Guid.Parse("E169494E-1B91-4053-AEA2-B4E1555B5B9C"),
	    };

        public static Guid[] ContactGuids =
	    {
	        Guid.Parse("CDADA936-9C83-4067-9A59-772EC83E1DBB"),
	        Guid.Parse("1E521CE5-2687-41FF-8D47-45DE29A94D46"),
	        Guid.Parse("E169494E-1B91-4E53-AEA2-B4E1555B5B9C"),
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
	            CompanyId = CompanyGuids[1],
	            Email = "WendyWolowitz@Wloh.Wlah",
	            Name = "Wendy Wolowitz",
	            Phone = "778778822"
	        },
	        new Contact
	        {
	            Id = ContactGuids[2],
	            CompanyId = CompanyGuids[2],
	            Email = "Johnny@JohnnySolver.com",
	            Name = "JohnnySolever",
	            Phone = "000000000"
	        },
	    };

    public App ()
		{
			InitializeComponent();

			base.MainPage = new NavigationPage(new JobOfferListView());
		}

		protected override async void OnStart ()
		{
		    var db = new SQLiteAsyncConnection(
		        DependencyService.Get<ISQLiteConnectionStringFactory>().Create("databName"));
            await db.CreateTablesAsync<Contact, JobOffer, Address, Company, Interview>();
		    // await db.InsertAllAsync(Contacts);
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	    private void PopulateDb()
	    {

	    }
	}
}
