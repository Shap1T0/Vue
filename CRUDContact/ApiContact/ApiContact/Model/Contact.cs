using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContact.Model
{
    public class Contact
    {
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string GivenName { get; set; }
    }
}
