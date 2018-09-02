using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
   public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadById(int id);

        IEnumerable<Pet> ReadAll();

        Pet ReadOne(int id);

        Pet Update(Pet petUpdate);

        Pet Delete(int id);
        
    }
}
