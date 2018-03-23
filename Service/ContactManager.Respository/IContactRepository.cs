using ContactManager.Domain;
using ContactManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Respository
{
    public interface IContactRepository
    {
        Task<List<ContactDomain>> GetContactsAsync();

        Task<ContactDomain> GetContactAsync(int contactId);

        Task<bool> IsContactExists(int contactId);

        Task<bool> AddContactAsync(ContactDomain contactDomain);

        Task<bool> UpdateContactAsync(ContactDomain contactDomain);

        Task<bool> DeleteContactAsync(int contactId);

        Task<bool> DeleteContactAsync(ContactDomain contactDomain);

        Task<bool> AddContactAsync(List<ContactDomain> contactDomainList);

        Task<bool> UpdateContactAsync(List<ContactDomain> contactDomainList);

    }
}
