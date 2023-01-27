using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalim.HR.DataAccess
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;
        public AddressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> CreateAddress(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAddress(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
            if (address != null)
            {
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Address> GetAddress(int id)
        {
            return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _dbContext.Addresses.ToListAsync();
        }
        public async Task<Address> UpdateAddress(int id, Address address)
        {
            var updatedaddress = _dbContext.Addresses.Attach(address);
            updatedaddress.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return address;
        }
    }
}
