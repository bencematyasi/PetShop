﻿using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data.Reporsitories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp
{
    public class Printer
    {
        private IPetRepository petRepository;

        public Printer()
        {
            petRepository = new PetRepository();
            InitData();
            StartUI();
        }
        
        void InitData()
        {
            Pet brunoDoggy = new Pet
            {
                Name = "Bruno",
                Type = "dog",
                BirthDay = new DateTime(2010, 10, 05).Date,
                SoldDate = new DateTime(2010, 11, 05).Date,
                Color = "blueish",
                PreviousOwner = "Danny Boy",
                Price = 40
            };
            petRepository.Creat(brunoDoggy);

            Pet armandCat = new Pet
            {
                Name = "Armand",
                Type = "cat",
                BirthDay = new DateTime(2014, 11, 19).Date,

                SoldDate = new DateTime(2010, 12, 24).Date,
                Color = "black",
                PreviousOwner = "Alexandra Bummer",
                Price = 30
            };
            petRepository.Creat(armandCat);

            Pet sammyTurtle = new Pet
            {
                Name = "Sammy",
                Type = "turtle",
                BirthDay = new DateTime(2012, 01, 03).Date,

                SoldDate = new DateTime(2012, 03, 02).Date,
                Color = "green",
                PreviousOwner = "Franco Davis",
                Price = 10
            };
            petRepository.Creat(sammyTurtle);

            Pet thunderStromHorse = new Pet
            {
                Id = 1,
                Name = "Thunder Storm",
                Type = "horse",
                BirthDay = new DateTime(2017, 05, 09).Date,

                SoldDate = new DateTime(2017, 08, 15).Date,
                Color = "brownish",
                PreviousOwner = "Chris Richardson ",
                Price = 3000
            };
            petRepository.Creat(thunderStromHorse);
        }

        void StartUI()
        {
            string[] menuItems =
            {
                "List All Animals",
                "Search Pets by Type",
                "Creat New Pet",
                "Update a Pet",
                "Delete Pet",
                "Sort Pets by Price",
                "Show The 5 Cheapest Available Pets ",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ShowAllPets();
                        break;
                    case 2:
                        SearchByType();
                        break;
                    case 3:
                        AddPet();
                        break;
                    case 4:
                        UpdatePet();
                        break;
                    case 5:
                        DeletePet();
                        break;
                    case 6:
                        SortPetByPrice();
                        break;
                    case 7:
                        GetFiveCheapestPets();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

         private Pet FindPetById()
         {
            Console.WriteLine("Insert pet id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number ");
            }
            return petRepository.ReadById(id);
         }

        private void ShowAllPets()
        {
            var listOfPets = petRepository.ReadAll();
            foreach (var pet in listOfPets)
            {
                Console.WriteLine("name: {0}\ntype: {1}\nBirtday: {2}\nsold date: {3}\ncolor: {4}\nPrevious owner: {5}\nprice: ${6}",
                    pet.Name, pet.Type, pet.BirthDay, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price);
                Console.WriteLine("------------------------------");

            }
        }

        private void SearchByType()
        {
            throw new NotImplementedException();
        }

        private void AddPet()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Type: ");
            string type = Console.ReadLine();

            Console.WriteLine(" Enter Birthday: "); 
            DateTime birthday = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Sold Date: ");
            DateTime soldDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Color: ");
            string color = Console.ReadLine();

            Console.WriteLine("Enter Previous Owner of " + name);
            string previousOwner = Console.ReadLine();

            Console.WriteLine("Enter The Price");
            double price = Convert.ToDouble(Console.ReadLine());

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

            petRepository.Creat(pet);


        }

        private void UpdatePet()
        {
            throw new NotImplementedException();
        }

        private void DeletePet()
        {
            var petFound = FindPetById();
            if(petFound != null)
            {
                petRepository.Delete(petFound.Id);
            }
        }   

        private void SortPetByPrice()
        {
            throw new NotImplementedException();
        }
       
        private void GetFiveCheapestPets()
        {
            throw new NotImplementedException();
        }
        
        private int ShowMenu(string[] menuItems)
        {

            Console.WriteLine("Select a menu");
            Console.WriteLine("------------------------------");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine("{0}: {1}", (i + 1), menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
            {
                Console.WriteLine("Your selection must be between 1-6");
            }
            Console.WriteLine("Selection: " + selection);


            return selection;
        }



    }
}