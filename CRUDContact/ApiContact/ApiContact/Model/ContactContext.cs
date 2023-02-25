using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContact.Model
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
