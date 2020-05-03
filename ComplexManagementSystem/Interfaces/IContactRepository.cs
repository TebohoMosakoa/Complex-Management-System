using System;
using System.Collections.Generic;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts { get; }
        Contact GetContact(int Id);
        void AddContact(Contact contact);
        Contact RemoveContact(Contact contact);
    }
}
