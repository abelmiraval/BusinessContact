using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessContact.Entities;

namespace BusinessContact.DataAccess.Interfaces
{
    public interface IContactRepository
    {
        public Task<ICollection<Contact>> GetListContact();

        public  Task<int> CreateAsync(Contact contact);

        Task<Contact?> GetByIdAsync(int id);

        Task UpdateAsync();
    }
}