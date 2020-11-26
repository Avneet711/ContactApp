using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvolentApp.Models;

namespace EvolentApp.DataAccessLayer
{
    public class ContactRepository : IContactRepository
    {
        /// <summary>
        /// Gets full contact list from database
        /// </summary>
        /// <returns>List of contacts</returns>
        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = null;
            using (var ctx = new AppContacts())
            {
                contacts = ctx.Contacts.ToList();
            }
            return contacts;
        }

        /// <summary>
        /// Gets contact by ID from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single contact</returns>
        public Contact GetContactById(int id)
        {
            Contact contact = null;
            using (var ctx = new AppContacts())
            {
                contact = ctx.Contacts.Where(s => s.ContactId == id).FirstOrDefault();
            }
            return contact;
        }

        /// <summary>
        /// Adds new contact in database
        /// </summary>
        /// <param name="inputContact"></param>
        public void AddNewContact(Contact inputContact)
        {
            using (var ctx = new AppContacts())
            {
                ctx.Contacts.Add(inputContact);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Updates contact information in database
        /// </summary>
        /// <param name="inputContact"></param>
        /// <returns>integer indicating whether the operation was successful</returns>
        public int UpdateContact(Contact inputContact)
        {
            using (var ctx = new AppContacts())
            {
                var existingContact = ctx.Contacts.Where(s => s.ContactId == inputContact.ContactId)
                                                        .FirstOrDefault<Contact>();

                if (existingContact != null)
                {
                    existingContact.FirstName = inputContact.FirstName;
                    existingContact.LastName = inputContact.LastName;
                    existingContact.Email = inputContact.Email;
                    existingContact.PhoneNumber = inputContact.PhoneNumber;
                    existingContact.ContactStatus = inputContact.ContactStatus;

                    ctx.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Deletes contact from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteContact(int id)
        {
            using (var ctx = new AppContacts())
            {
                var contact = ctx.Contacts
                    .Where(s => s.ContactId == id)
                    .FirstOrDefault();

                ctx.Contacts.Remove(contact);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if email address already exists in database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckIfEmailExists(String email,int contactId)
        {
            bool result;
            using (var ctx = new AppContacts())
            {
                //Update existing contact
                if (contactId > 0)
                {
                   result  = ctx.Contacts.Any(x => x.Email == email && x.ContactId != contactId);
                }
                //New contact
                else
                {
                   result = ctx.Contacts.Any(x => x.Email == email);
                }
                return result;
            }

        }
    }


        
}