using System;
using System.IO;
using JobApp.Droid.DatabaseService;
using XamarinToolkit.Interfaces.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnectionFactory))]

namespace JobApp.Droid.DatabaseService
{
    public class SQLiteConnectionFactory : ISQLiteConnectionStringFactory
    {
        public string Create(string name)
        {
            var directory = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);

            return Path.Combine(directory, name);
        }
    }
}