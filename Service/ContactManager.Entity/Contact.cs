using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Entity
{
    public class Contact //: BaseEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
