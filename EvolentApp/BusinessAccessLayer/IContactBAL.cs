using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolentApp.ViewModels;

namespace EvolentApp.BusinessAccessLayer
{
    public interface IContactBAL
    {
        List<ContactViewModel> GetAllContacts();
        ContactViewModel GetContactById(int id);
        void AddNewContact(ContactViewModel inputContact);
        int UpdateContact(ContactViewModel inputContact);
        void DeleteContact(int id);
        bool CheckIfEmailExists(String email, int contactId);
    }
}
