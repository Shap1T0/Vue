using ApiContact.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        ContactContext db;
        public ContactController(ContactContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            return await db.Contact.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            Contact user = await db.Contact.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Contact>> Post(Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            db.Contact.Add(contact);
            await db.SaveChangesAsync();
            return Ok(contact);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Contact>> Put(Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (!db.Contact.Any(x => x.Id == contact.Id))
            {
                return NotFound();
            }

            db.Update(contact);
            await db.SaveChangesAsync();
            return Ok(contact);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> Delete(Guid id)
        {
            Contact contact = db.Contact.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            db.Contact.Remove(contact);
            await db.SaveChangesAsync();
            return Ok(contact);
        }
    }
}
