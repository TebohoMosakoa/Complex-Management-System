using System;
using System.Collections.Generic;
using System.Linq;
using ComplexManagementSystem.Data;
using ComplexManagementSystem.Interfaces;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        public readonly ApplicationDbContext _context;
        public HouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<House> GetHouses => _context.Houses;
        public void AddHouse(House house)
        {
            _context.Houses.Add(house);
            _context.SaveChanges();
        }

        public House GetHouse(int Id)
        {
            return _context.Houses.Find(Id);
        }

        public House RemoveHouse(House house)
        {
            if(house != null)
            {
                _context.Houses.Remove(house);
                _context.SaveChanges();
            }
            return house;
        }

        public House UpdateHouse(House house)
        {
            var newHouse = _context.Houses.Attach(house);
            newHouse.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return house;
        }
    }
}
