using ContactManager.Data;
using ContactManager.Domain;
using ContactManager.Entity;
using ContactManager.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Respository.Implementation
{
    public class ContactRepository : IContactRepository
    {
        #region Private Members
        private IContactManagerContext _contactManagerContext { get; set; }
        #endregion Private Members

        #region Constructor
        public ContactRepository(IConfigurationRoot configuration, IContactManagerContext contactManagerContext)
        {
            _contactManagerContext = contactManagerContext;
        }


        #endregion Constructor

        #region Public Methods
        public async Task<List<ContactDomain>> GetContactsAsync()
        {
            return DomainToEntityMapper.MapEntityListToDomainList(await _contactManagerContext.Contacts.ToListAsync());
        }

        public async Task<ContactDomain> GetContactAsync(int contactId)
        {
            return DomainToEntityMapper.MapEntityToDomain(await GetContactEnitityAsync(contactId));
        }

        public async Task<bool> IsContactExists(int contactId)
        {
            return await _contactManagerContext.Contacts.AsNoTracking().Where(c => c.ID == contactId).SingleOrDefaultAsync() != null;
        }

        public async Task<bool> AddContactAsync(ContactDomain contactDomain)
        {
            await _contactManagerContext.Contacts.AddAsync(DomainToEntityMapper.MapDomainToEntity(contactDomain));
            return await _contactManagerContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateContactAsync(ContactDomain contactDomain)
        {
            _contactManagerContext.Contacts.Update(DomainToEntityMapper.MapDomainToEntity(contactDomain));
            return await _contactManagerContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            _contactManagerContext.Contacts.Remove(await GetContactEnitityAsync(contactId));
            return await _contactManagerContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteContactAsync(ContactDomain contactDomain)
        {
            _contactManagerContext.Contacts.Remove(DomainToEntityMapper.MapDomainToEntity(contactDomain));
            return await _contactManagerContext.SaveChangesAsync();
        }

        public Task<bool> AddContactAsync(List<ContactDomain> contactDomainList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContactAsync(List<ContactDomain> contactDomainList)
        {
            throw new NotImplementedException();
        }
        #endregion Public Methods

        #region Private Methods
        private async Task<Contact> GetContactEnitityAsync(int contactId)
        {
            return await _contactManagerContext.Contacts.Where(c => c.ID == contactId).SingleOrDefaultAsync();
        }
        #endregion Private Methods
    }
}
