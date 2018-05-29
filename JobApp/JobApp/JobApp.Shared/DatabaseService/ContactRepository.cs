using System;
using SQLite;
using System.Threading.Tasks;
using JobApp.Shared.Models;

namespace JobApp.Shared.DatabaseServices
{
    public class ContactRepository
    {
        private SQLiteAsyncConnection _database;

        public ContactRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Contact> TryGetContactByIdAsync(Guid id)
        {
            try
            {
                return await _database
                    .Table<Contact>()
                    .Where(contact => contact.Id == id)
                    .FirstAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryAddContactAsync(Contact contact)
        {
            try
            {
                await _database.InsertAsync(contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteContactAsync(Contact contact)
        {
            try
            {
                await _database.DeleteAsync(contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryUpdateContactAsync(Contact contact)
        {
            try
            {
                await _database.UpdateAsync(contact);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
