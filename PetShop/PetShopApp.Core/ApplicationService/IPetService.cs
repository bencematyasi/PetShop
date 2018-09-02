using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        //new pet
        Pet NewPet( string name, string type, 
                    DateTime birthday, DateTime soldDate, 
                    string color, string previousOwner, 
                    double price);
        //create pet
        Pet CreatePet(Pet pet);
        //read pet
        Pet FindPetById(int id);
        //
        List<Pet> GetAllPets();
        //update pet
        Pet UpdatePet(Pet pet);
        //Get one pet for update
        Pet GetOneId(Pet onePet);
        //delete pet
        Pet DeletePet(int id);
        //Search a type
        List<Pet> SearchType(string input);
        //Sorted list for sorted pet list show
        List<Pet> SortingPetsList();
        //Sorted list for get five cheapest pets 
        List<Pet> GetFiveCheapsestPets();




    }
}
