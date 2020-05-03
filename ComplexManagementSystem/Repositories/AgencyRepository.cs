using System;
using System.Collections.Generic;
using ComplexManagementSystem.Data;
using ComplexManagementSystem.Interfaces;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly ApplicationDbContext _context;
        public AgencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Agency> GetAgencies => _context.Agencies;

        public void AddAgency(Agency agency)
        {
            _context.Agencies.Add(agency);
            _context.SaveChanges();
        }

        public Agency GetAgency(int Id)
        {
            return _context.Agencies.Find(Id);
        }

        public Agency RemoveAgency(Agency agency)
        {
            if(agency != null)
            {
                _context.Agencies.Remove(agency);
                _context.SaveChanges();
            }
            return agency;
        }

        public Agency UpdateAgency(Agency agency)
        {
            var newAgency = _context.Agencies.Attach(agency);
            newAgency.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return agency;
        }
    }
}
