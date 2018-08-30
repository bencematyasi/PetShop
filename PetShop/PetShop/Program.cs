using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data.Reporsitories;
using System;

namespace PetShop
{
    class Program
    {
        static IPetRepository petRepository;

        static void Main(string[] args)
        {
            petRepository = new PetRepository();
            Pet brunoDoggy = new Pet
            {
                Id = 1,
                Name = "Bruno",
                Type = "dog",
                BirthDay = new DateTime(2010, 10, 05).Date,
                
                SoldDate = new DateTime(2010, 11, 05).Date,
                Color = "blueish",
                PreviousOwner = "Danny Boy",
                Price = 40
            };

            Console.WriteLine("name: {0}\ntype: {1}\nBirtday: {2}\nsold date: {3}\ncolor: {4}\nPrevious owner: {5}\nprice: ${6}", brunoDoggy.Name, brunoDoggy.Type, brunoDoggy.BirthDay, brunoDoggy.SoldDate, brunoDoggy.Color, brunoDoggy.PreviousOwner, brunoDoggy.Price);
            
            Console.ReadLine();

        }
    }
}
 