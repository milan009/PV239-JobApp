using System;
using System.IO;
using JobApp.iOS.DatabaseService;
using JobApp.Shared.Interfaces.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnectionStringFactory))]

namespace JobApp.iOS.DatabaseService
{
    class SQLiteConnectionStringFactory : ISQLiteConnectionStringFactory
    {
        public string Create(string name)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, name);
        }
    }
}
