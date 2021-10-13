using SMSGatewayAPI.Models;
using System;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Repositories
{
    public interface IContactRepository
    {
        //Create user interface


        Task CreateContactAsync(Contact contact, string password);

        //Get user interface
        Task<Contact> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(string id);
        Task<Contact> GetContactByFirstNameAsync(string firstName);
        Task<Contact> GetContactByLastNameAsync(string lastName);
        Task<Contact> GetContactByEmailAsync(string email);
        Task<Contact> GetContactByPhoneNumberAsync(string phoneNumber);

        //Update user interface
        Task<Contact> UpdateContact(string id);

        //Delete user interface
        Task<Contact> DeleteContact(string id);
    }
}
