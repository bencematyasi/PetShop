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
        private List<Pet> pets = new List<Pet>();

        public Pet Creat(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Pet ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
