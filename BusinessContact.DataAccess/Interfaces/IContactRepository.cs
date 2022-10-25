using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessContact.Entities;

namespace BusinessContact.DataAccess.Interfaces
{
    public interface IContactRepository
    {
        Task<ICollection<Contact>> GetListContact();

        Task<int> CreateAsync(Contact contact);

        Task<Contact?> GetByIdAsync(int id);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}