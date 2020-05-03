using System;
using System.Collections.Generic;
using ComplexManagementSystem.Data;
using ComplexManagementSystem.Interfaces;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetContacts => _context.Contacts;

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public Contact GetContact(int Id)
        {
            return _context.Contacts.Find(Id);
        }

        public Contact RemoveContact(Contact contact)
        {
            if(contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return contact;
        }
    }
}
