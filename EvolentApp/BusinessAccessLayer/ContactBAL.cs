using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvolentApp.Models;
using EvolentApp.ViewModels;
using EvolentApp.DataAccessLayer;

namespace EvolentApp.BusinessAccessLayer
{
    public class ContactBAL : IContactBAL
    {
        private IContactRepository contactDAL;

        //Contructor injection
        public ContactBAL(IContactRepository _contactDAL)
        {
            contactDAL = _contactDAL;
        }

        //Business layer method to get contact list. Maps data model fields to business model.
        public List<ContactViewModel> GetAllContacts()
        {
            List<ContactViewModel> contactList = new List<ContactViewModel>();
            List<Contact> contacts = contactDAL.GetAllContacts();

            foreach(Contact c in contacts)
            {
                contactList.Add(new ContactViewModel()
                {
                    ContactId = c.ContactId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    ContactStatus = c.ContactStatus
                });
            }
            return contactList;

        }

        //Business layer method to get contact by ID. Maps data model fields to business model.
        public ContactViewModel GetContactById(int id)
        {
            Contact rawContact = contactDAL.GetContactById(id);
            ContactViewModel contact =  new ContactViewModel()
             {
                 ContactId = rawContact.ContactId,
                 FirstName = rawContact.FirstName,
                 LastName = rawContact.LastName,
                 Email = rawContact.Email,
                 PhoneNumber = rawContact.PhoneNumber,
                 ContactStatus = rawContact.ContactStatus
             };

            return contact;
        }

        //Business layer method to add new contact. Maps input business model fields to data model.
        public void AddNewContact(ContactViewModel inputContact)
        {
            Contact contact = new Contact()
            {
                FirstName = inputContact.FirstName,
                LastName = inputContact.LastName,
                Email = inputContact.Email,
                PhoneNumber = inputContact.PhoneNumber,
                ContactStatus = inputContact.ContactStatus
            };
            contactDAL.AddNewContact(contact);
        }

        //Business layer method to update existing contact. Maps input business model fields to data model.
        public int UpdateContact(ContactViewModel inputContact)
        {
            Contact contact = new Contact()
            {
                ContactId = inputContact.ContactId,
                FirstName = inputContact.FirstName,
                LastName = inputContact.LastName,
                Email = inputContact.Email,
                PhoneNumber = inputContact.PhoneNumber,
                ContactStatus = inputContact.ContactStatus
            };
            return contactDAL.UpdateContact(contact);
        }

        //Business layer method to delete existing contact
        public void DeleteContact(int id)
        {
            contactDAL.DeleteContact(id);
        }

        //Business layer method to check if email exists
        public bool CheckIfEmailExists(String email, int contactId)
        {
            return contactDAL.CheckIfEmailExists(email, contactId);
        }
    }
}