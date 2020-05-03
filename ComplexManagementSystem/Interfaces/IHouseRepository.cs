using System;
using System.Collections.Generic;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Interfaces
{
    public interface IHouseRepository
    {
        IEnumerable<House> GetHouses { get;}
        House GetHouse(int Id);
        void AddHouse(House house);
        House UpdateHouse(House house);
        House RemoveHouse(House house);
    }
}
