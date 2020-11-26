using EvolentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EvolentApp.BusinessAccessLayer;
using EvolentApp.ViewModels;

namespace EvolentApp.Controllers
{
    public class AppContactController : ApiController
    {
        public IContactBAL contactBAL;

        //Constructor injection
        public AppContactController(IContactBAL _contactBAL)
        {
            contactBAL = _contactBAL;
        }

        //API Controller action method to get contact list
        [Route("api/AppContact/GetAllContacts")]
        public IHttpActionResult GetAllContacts()
        {
            List<ContactViewModel> contacts = contactBAL.GetAllContacts();

            if (contacts.Count == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        //API Controller action method to get contact by ID
        [Route("api/AppContact/GetContactById")]
        public IHttpActionResult GetContactById(int id)
        {
            ContactViewModel contact = contactBAL.GetContactById(id);

            if (contact==null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        //API Controller action method to add new contact
        public IHttpActionResult PostNewContact(ContactViewModel inputContact)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            if(contactBAL.CheckIfEmailExists(inputContact.Email, 0))
            {
                return Conflict();
            }

            contactBAL.AddNewContact(inputContact);

            return Ok();
        }

        //API Controller action method to update existing contact
        [HttpPut]
        public IHttpActionResult UpdateContact(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            if (contactBAL.CheckIfEmailExists(contact.Email, contact.ContactId))
            {
                return Conflict();
            }

            int updateResult = contactBAL.UpdateContact(contact);
            if(updateResult==0)
            {
                return NotFound();
            }

            return Ok();
        }

        //API Controller action method to delete existing contact
        public IHttpActionResult DeleteContact(int id)
        {
            if (id <= 0)
                return BadRequest("Contact ID is invalid");

            contactBAL.DeleteContact(id);

            return Ok();
        }
    }
}
