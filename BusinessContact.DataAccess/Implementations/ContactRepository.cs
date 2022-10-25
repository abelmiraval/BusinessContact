using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessContact.DataAccess.Interfaces;
using BusinessContact.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessContact.DataAccess.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly BusinessContactDbContext _context;

        public ContactRepository(BusinessContactDbContext context)
        {
            _context = context;
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _context.Set<Contact>()
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Contact>> GetListContact()
        {
            var contacts = await _context.Set<Contact>()
                .Include(c => c.Business)
                .ToListAsync();

            return contacts;
        }

        public async Task<int> CreateAsync(Contact contact)
        {
            await _context.Set<Contact>().AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact.Id;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                entity.Status = false;

            await _context.SaveChangesAsync();
        }

    }
}