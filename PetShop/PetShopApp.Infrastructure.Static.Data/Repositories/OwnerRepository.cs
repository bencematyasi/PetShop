using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        static int id = 1;
        private List<Owner> _owners = new List<Owner>();

        public Owner Create(Owner owner)
        {
            owner.Id = id++;
            _owners.Add(owner);
            return owner;

        }

        public Owner Delete(int id)
        {
            var ownerFound = this.ReadById(id);
            if (ownerFound != null)
            {
                _owners.Remove(ownerFound);
                return ownerFound;
            }
            return null;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _owners;
        }

        public Owner ReadById(int id)
        {
            foreach (var owner in _owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }
            return null;

        }

        public Owner ReadOne(int id)
        {
            return _owners[id];
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDB = ReadById(ownerUpdate.Id);
            if (ownerFromDB != null)
            {
                ownerFromDB.FirstName = ownerFromDB.FirstName;
                ownerFromDB.LastName = ownerFromDB.LastName;
                ownerFromDB.Address = ownerFromDB.Address;
                ownerFromDB.PhoneNumber = ownerFromDB.PhoneNumber;
                ownerFromDB.Email = ownerFromDB.Email;
                return ownerFromDB;
            }
            return null;
        }
    }
}
