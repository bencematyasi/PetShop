using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
   public interface IPetRepository
    {
        Pet Creat(Pet pet);

        Pet ReadById(int id);

        List<Pet> ReadAll();

        Pet ReadOne(int id);

        Pet Update(Pet petUpdate);

        Pet Delete(int id);

        //void Sorting()

        
    }
}
