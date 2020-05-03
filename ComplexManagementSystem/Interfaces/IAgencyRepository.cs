using System;
using System.Collections.Generic;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Interfaces
{
    public interface IAgencyRepository
    {
        IEnumerable<Agency> GetAgencies { get; }
        Agency GetAgency(int Id);
        void AddAgency(Agency agency);
        Agency UpdateAgency(Agency agency);
        Agency RemoveAgency(Agency agency);
    }
}
