using ContactManager.Domain;
using ContactManager.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Business
{
    public interface IContactManager
    {
        Task<ContactListResponse> GetContactsAsync();

        Task<ContactDto> GetContactAsync(int contactId);

        Task<bool> AddContactAsync(ContactDomain contactDomain);

        Task<bool> UpdateContactAsync(ContactDomain contactDomain);

        Task<bool> DeleteContactAsync(int contactId);
    }
}
