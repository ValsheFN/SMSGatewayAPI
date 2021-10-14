using SMSGatewayAPI.Data;
using SMSGatewayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Repositories
{
    public interface IContactRepository
    {
        Task CreateAsync(Contact contact);
        void Remove(Contact contact);
        IEnumerable<Contact> GetAll();
        Task<Contact> GetByIdAsync(string id);
    }

    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDBContext _db;

        public ContactRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Contact contact)
        {
            await _db.Contacts.AddAsync(contact);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _db.Contacts;
        }

        public async Task<Contact> GetByIdAsync(string id)
        {
            return await _db.Contacts.FindAsync(id);
        }

        public void Remove(Contact contact)
        {
            _db.Contacts.Remove(contact);
        }
    }
}
