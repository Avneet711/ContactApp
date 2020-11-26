using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvolentApp.ViewModels;
using System.Net.Http;
using System.Configuration;

namespace EvolentApp.Controllers
{
    public class ContactController : Controller
    {
        String apiBaseUrl = ConfigurationManager.AppSettings["ApiUrl"];

        //Controller action method to get contact list
        public ActionResult Index()
        {
            try
            { 
                IEnumerable<ContactViewModel> contacts = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    //HTTP GET
                    var responseTask = client.GetAsync("GetAllContacts");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<ContactViewModel>>();
                        readTask.Wait();
                        contacts = readTask.Result;
                    }
                    else
                    {
                        contacts = Enumerable.Empty<ContactViewModel>();
                        ModelState.AddModelError(string.Empty, "Server Error - " + result.StatusCode + ". Please contact administrator.");
                    }
                }
                return View(contacts);
            }
            catch(Exception)
            {
                return View("Error");
            }
        }

        public ActionResult CreateContact()
        {
            return View();
        }

        //Controller action method to add new contact
        [HttpPost]
        public ActionResult CreateContact(ContactViewModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ContactViewModel>("PostNewContact", contact);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                        {
                            ModelState.AddModelError("Email", "Email already exists.");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Server Error - " + result.StatusCode + ". Please contact administrator.");
                        }
                    }
                }

                return View(contact);
            }
            catch(Exception)
            {
                return View("Error");
            }
        }

        //Controller action method to get the existing contact to be updated
        public ActionResult EditContact(int id)
        {
            try
            {
                ContactViewModel contact = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    //HTTP GET
                    var responseTask = client.GetAsync("GetContactById?id=" + id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ContactViewModel>();
                        readTask.Wait();

                        contact = readTask.Result;
                    }
                }

                return View(contact);
            }
            catch(Exception)
            {
                return View("Error");
            }
        }

        //Controller action method to update existing contact
        [HttpPost]
        public ActionResult EditContact(ContactViewModel contact)
        {
            try
            {
                contact.ContactId = Convert.ToInt32(TempData["ContactId"]);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);

                    var putTask = client.PutAsJsonAsync<ContactViewModel>("UpdateContact", contact);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                        {
                            ModelState.AddModelError("Email", "Email already exists.");
                        }
                    }
                }

                return View(contact);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //Controller action method to delete existing contact
        public ActionResult DeleteContact(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    var deleteTask = client.DeleteAsync("DeleteContact?id=" + id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }


}