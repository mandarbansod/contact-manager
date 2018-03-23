using ContactManager.Common.CustomExceptions;
using ContactManager.Domain;
using ContactManager.Dto;
using ContactManager.Entity;
using ContactManager.Mappers;
using ContactManager.Respository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Business.Implementation
{
    public class ContactManager : IContactManager
    {
        #region Private Members 
        private IContactRepository _contactRepository { get; set; }
        #endregion Private Members

        #region Constructor
        public ContactManager(IConfigurationRoot configuration, IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        #endregion Constructor

        #region Public Methods
        public async Task<ContactListResponse> GetContactsAsync()
        {
            var query = await _contactRepository.GetContactsAsync().ConfigureAwait(false);

            return DtoToDomainMapper.MapDomainListToContactListResponse(query);
        }

        public async Task<ContactDto> GetContactAsync(int contactId)
        {
            ContactDto contactDto = new ContactDto();

            var contactDomain = await _contactRepository.GetContactAsync(contactId).ConfigureAwait(false);

            if (contactDomain != null)
            {
                contactDto = DtoToDomainMapper.MapDomainToDto(contactDomain); 
            }
            else
            {
                throw new ContactNotFoundException();
            }

            return contactDto;
        }

        public async Task<bool> AddContactAsync(ContactDomain contactDomain)
        {
            return await _contactRepository.AddContactAsync(contactDomain).ConfigureAwait(false);
        }

        public async Task<bool> UpdateContactAsync(ContactDomain contactDomain)
        {
            if (await _contactRepository.IsContactExists(contactDomain.ID).ConfigureAwait(false))
            {
                return await _contactRepository.UpdateContactAsync(contactDomain).ConfigureAwait(false);
            }
            else
            {
                throw new ContactNotFoundException();
            }
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var contactEntity = await _contactRepository.GetContactAsync(contactId).ConfigureAwait(false);

            if (contactEntity != null)
            {
                return await _contactRepository.DeleteContactAsync(contactId);
            }
            else
            {
                throw new ContactNotFoundException();
            }
        }
        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
