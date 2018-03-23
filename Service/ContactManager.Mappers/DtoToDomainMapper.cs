using AutoMapper;
using ContactManager.Domain;
using ContactManager.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Mappers
{
    public class DtoToDomainMapper
    {
        #region Private Members
        private static IMapper _mapper { get; set; }
        #endregion Private Members

        #region Public Members

        #endregion Public Members

        #region Constructor

        #endregion Constructor

        #region Public Methods
        public void ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactDomain, ContactDto>();

                cfg.CreateMap<ContactDto, ContactDomain>();

                cfg.CreateMap<PostContactRequest, ContactDomain>()
                    .ForMember(p => p.Email, m => m.MapFrom(src => src.Email))
                    .ForMember(p => p.FirstName, m => m.MapFrom(src => src.FirstName))
                    .ForMember(p => p.IsActive, m => m.MapFrom(src => src.IsActive))
                    .ForMember(p => p.LastName, m => m.MapFrom(src => src.LastName))
                    .ForMember(p => p.PhoneNumber, m => m.MapFrom(src => src.PhoneNumber))
                    .ForMember(p => p.ID, m => m.Ignore());

                cfg.CreateMap<PutContactRequest, ContactDomain>()
                    .ForMember(p => p.Email, m => m.MapFrom(src => src.Email))
                    .ForMember(p => p.FirstName, m => m.MapFrom(src => src.FirstName))
                    .ForMember(p => p.IsActive, m => m.MapFrom(src => src.IsActive))
                    .ForMember(p => p.LastName, m => m.MapFrom(src => src.LastName))
                    .ForMember(p => p.PhoneNumber, m => m.MapFrom(src => src.PhoneNumber))
                    .ForAllOtherMembers(p => p.Ignore());

                cfg.CreateMap<List<ContactDomain>, ContactListResponse>()
                    .ForMember(p => p.ContactList, m => m.MapFrom(src => src));

            });

            _mapper = config.CreateMapper();
        }

        public static ContactDto MapDomainToDto(ContactDomain contactDomain)
        {
            return _mapper.Map<ContactDto>(contactDomain);
        }

        public static ContactListResponse MapDomainListToContactListResponse(List<ContactDomain> contactDomainList)
        {
            return _mapper.Map<ContactListResponse>(contactDomainList);
        }

        public static ContactDomain MapDtoToDomain(ContactDto contactDto)
        {
            return _mapper.Map<ContactDomain>(contactDto);
        }

        public static ContactDomain MapDtoToDomain(PostContactRequest postContactRequest)
        {
            return _mapper.Map<ContactDomain>(postContactRequest);
        }

        public static ContactDomain MapDtoToDomain(PutContactRequest putContactRequest, int contactId)
        {
            var contactDomain = _mapper.Map<ContactDomain>(putContactRequest);
            contactDomain.ID = contactId;

            return contactDomain;
        }
        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
