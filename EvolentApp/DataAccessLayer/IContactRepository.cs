using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvolentApp.Models;

namespace EvolentApp.DataAccessLayer
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void AddNewContact(Contact inputContact);
        int UpdateContact(Contact inputContact);
        void DeleteContact(int id);
        bool CheckIfEmailExists(String email, int contactId);
    }
}