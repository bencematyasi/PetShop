using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
            
        }
        public Pet NewPet(string name, string type, DateTime birthday, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                BirthDay = birthday,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.ReadAll().ToList() ;
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.BirthDay = petUpdate.BirthDay;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;

            return pet;
        }
   
        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }
        
        public List<Pet> SearchType(string input)
        {
           return _petRepo.ReadAll().Where(p => p.Type == input).ToList() ;
        }

        public Pet GetOneId(Pet onePet)
        {
            return _petRepo.ReadOne(onePet.Id);
        }

        public List<Pet> SortingPetsList()
        {
           return _petRepo.ReadAll().OrderBy(p => p.Price).ToList();
        }

        public List<Pet> GetFiveCheapsestPets()
        {
            return _petRepo.ReadAll().OrderBy(p => p.Price).Take(5).ToList();
        }
    }
}
