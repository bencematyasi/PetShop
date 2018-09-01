using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data.Reporsitories
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        private List<Pet> _pets = new List<Pet>();

        public Pet Creat(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public List<Pet> ReadAll()
        {
            return _pets;  
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }

            }
            return null;
        }

        public Pet Update(Pet petUpdate)
        {
            var petFromDB = this.ReadById(petUpdate.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Type = petUpdate.Type;
                petFromDB.BirthDay = petUpdate.BirthDay;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.Color = petUpdate.Color;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;

                return petFromDB;
            }
            return null;
        }
        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);
            if(petFound != null)
            {
                _pets.Remove(petFound);
                return petFound;
            }
            return null;

        }
        
        public Pet ReadOne(int id)
        {
            return _pets[id];
        }

        //public void Sorting()
        //{
        //    _pets.Sort();
        }

}
