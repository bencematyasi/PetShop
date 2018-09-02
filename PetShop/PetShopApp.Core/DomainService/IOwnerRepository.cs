using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);

        Owner ReadById(int id);

        IEnumerable<Owner> ReadAll();
        //for Update
        Owner ReadOne(int id);

        Owner Update(Owner ownerUpdate);

        Owner Delete(int id);
    }
}
