using AutoMapper;
using ContactManager.Domain;
using ContactManager.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Mappers
{
    public class DomainToEntityMapper
    {
        #region Private Members

        #endregion Private Members
        private static IMapper _mapper { get; set; }
        #region Public Members

        #endregion Public Members

        #region Constructor

        #endregion Constructor

        #region Public Methods
        public void ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDomain>();

                cfg.CreateMap<ContactDomain, Contact>();
            });

            _mapper = config.CreateMapper();
        }

        public static ContactDomain MapEntityToDomain(Contact contactEntity)
        {
            return _mapper.Map<ContactDomain>(contactEntity);
        }

        public static Contact MapDomainToEntity(ContactDomain contactDomain)
        {
            return _mapper.Map<Contact>(contactDomain);
        }

        public static List<ContactDomain> MapEntityListToDomainList(List<Contact> contactList)
        {
            return _mapper.Map<List<Contact>, List<ContactDomain>>(contactList); 
        }

        public static List<Contact> MapDomainListToEntityList(List<ContactDomain> contactDomainList)
        {
            return _mapper.Map<List<ContactDomain>, List<Contact>>(contactDomainList);
        }
        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
