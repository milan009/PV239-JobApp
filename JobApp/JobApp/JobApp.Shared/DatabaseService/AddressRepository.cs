using System;
using SQLite;
using System.Threading.Tasks;
using JobApp.Shared.Models;

namespace JobApp.Shared.DatabaseService
{
    public class AddressRepository
    {
        private SQLiteAsyncConnection _database;

        public AddressRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Address> TryGetAddressByIdAsync(Guid id)
        {
            try
            {
                return await _database
                    .Table<Address>()
                    .Where(address => address.Id == id)
                    .FirstAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryAddAddressAsync(Address address)
        {
            try
            {
                await _database.InsertAsync(address);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteAddressAsync(Address address)
        {
            try
            {
                await _database.DeleteAsync(address);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryUpdateAddressAsync(Address address)
        {
            try
            {
                await _database.UpdateAsync(address);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
