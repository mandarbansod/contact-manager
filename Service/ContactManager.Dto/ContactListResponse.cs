using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Dto
{
    public class ContactListResponse
    {
        public List<ContactDto> ContactList { get; set; }

        public ContactListResponse()
        {
            ContactList = new List<ContactDto>();
        }
    }
}
