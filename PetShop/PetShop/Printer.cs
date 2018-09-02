
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data.Reporsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp
{
    public class Printer : IPrinter
    {
        #region Repository area
        private IPetService _petService;
        #endregion

        #region Printer constructor
        public Printer(IPetService petService)    
        {
            _petService = petService;
            InitData();
            
        }
        #endregion

        #region InitData method, move to AplicationService
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
            _petService.CreatePet(brunoDoggy);

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
            _petService.CreatePet(armandCat);

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
            _petService.CreatePet(sammyTurtle);

            Pet thunderStromHorse = new Pet
            {

                Name = "Thunder Storm",
                Type = "horse",
                BirthDay = new DateTime(2017, 05, 09).Date,
                SoldDate = new DateTime(2017, 08, 15).Date,
                Color = "brownish",
                PreviousOwner = "Chris Richardson ",
                Price = 3000
            };
            _petService.CreatePet(thunderStromHorse);

            Pet lessieDoggy = new Pet
            {
                Name = "Lessie",
                Type = "dog",
                BirthDay = new DateTime(2011, 05, 23).Date,
                SoldDate = new DateTime(2012, 06, 29).Date,
                Color = "white-brownish",
                PreviousOwner = "David Pizzaro",
                Price = 22
            };
            _petService.CreatePet(lessieDoggy);

            Pet furmyCat = new Pet
            {
            
                Name = "Furmy",
                Type = "cat",
                BirthDay = new DateTime(2008, 02, 10).Date,
                SoldDate = new DateTime(2008, 03, 21).Date,
                Color = "brownish",
                PreviousOwner = "Chris Richardson ",
                Price = 29
            };
            _petService.CreatePet(furmyCat);
            
        }
        #endregion

        #region UI Part
         public void StartUI()
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
                        //List all the pets
                        Console.Clear();
                        var pets = _petService.GetAllPets();
                        ListAllPets(pets);
                        break;
                    case 2:
                        //Searched By Type
                        Console.Clear();
                        var input = AskQuestion("Search by Type\nEnter the searched type: ");
                        var searchedType =_petService.SearchType(input);
                        GetSearchedType(searchedType);
                        break;
                    case 3:
                        //CreatPet
                        Console.Clear();
                        string name = AskQuestion("Enter Name: ");
                        string type = AskQuestion("Enter Type: ");
                        DateTime bithday = DateTime.Parse(AskQuestion("Enter Birthday: "));
                        DateTime soldDate = DateTime.Parse(AskQuestion("Enter Sold Date: "));
                        string color = AskQuestion("Enter color: ");
                        string previousOwner = AskQuestion("Enter Previous Owner of " + name);
                        double price = Convert.ToDouble(AskQuestion("Enter The Price"));
                        var pet = _petService.NewPet(name, type, bithday, soldDate, color, previousOwner, price);
                        _petService.CreatePet(pet);
                        break;
                    case 4:
                        //Update pet
                        Console.Clear();
                        var idForUpdate = PrintFindPetById();
                        var onePet = _petService.FindPetById(idForUpdate);
                        _petService.GetOneId(onePet);
                        Console.WriteLine("Updating {0}\n",onePet.Name);
                        string newName = AskQuestion("Enter Name: ");
                        string newType = AskQuestion("Enter Type: ");
                        DateTime newBirthday = DateTime.Parse(AskQuestion("Enter Birthday: "));
                        DateTime newSoldDate = DateTime.Parse(AskQuestion("Enter Sold Date: "));
                        string newColor = AskQuestion("Enter color: ");
                        string newPreviousOwner = AskQuestion("Enter Previous Owner of " + newName);
                        double newPrice = Convert.ToDouble(AskQuestion("Enter The Price"));
                        _petService.UpdatePet(new Pet() { 
                           Id = idForUpdate,
                           Name = newName, 
                           Type = newType, 
                           BirthDay = newBirthday, 
                           SoldDate = newSoldDate, 
                           Color = newColor, 
                           PreviousOwner = newPreviousOwner, 
                           Price = newPrice
                           });
                        break;
                    case 5:
                        //Delete
                        Console.Clear();
                        Console.WriteLine("Delete a Pet\n");
                        var idForDelete = PrintFindPetById();
                        var petDelete = _petService.FindPetById(idForDelete);
                        Console.WriteLine("{0} will be deleted\n", petDelete.Name);
                        _petService.DeletePet(idForDelete);
                        break;
                    case 6:
                        //Sort Pet by Price
                        Console.Clear();
                        List<Pet> sortedPetList = _petService.SortingPetsList();
                        SortPetByPrice(sortedPetList);
                        break;
                    case 7:
                        //get five cheapest pets
                        Console.Clear();
                        List<Pet> FiveCheapestList = _petService.GetFiveCheapsestPets();
                        GetFiveCheapestPets(FiveCheapestList);
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }
        #endregion


        int PrintFindPetById()
        {
            Console.WriteLine("Insert pet id: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number ");
            }
            return id;

        }

        string AskQuestion(string question)
        {

            Console.WriteLine(question);
            return Console.ReadLine();
        }

        #region List Pets code
        void ListAllPets(List<Pet> listOfPets)
        {
            
            Console.WriteLine("List of All Pets\n");
            foreach (var pet in listOfPets)
            {
                Console.WriteLine("id: {0}\nName: {1}\nType: {2}\nBirtday: {3}\nSold date: {4}\nColor: {5}\nPrevious owner: {6}\nPrice: ${7}",
                    pet.Id, pet.Name, pet.Type, pet.BirthDay, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price);
                Console.WriteLine("------------------------------");

            }
        }
        #endregion

        #region Searching code
        
        void GetSearchedType(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine("id: {0}\nName: {1}\nType: {2}\nBirtday: {3}\nSold date: {4}\nColor: {5}\nPrevious owner: {6}\nPrice: ${7}",
                     pet.Id, pet.Name, pet.Type, pet.BirthDay, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price);
                Console.WriteLine("------------------------------");
            }
              
        }
        #endregion 
        

        #region Sorting pet code
        void SortPetByPrice(List<Pet> sortedPetList)
        {
            Console.WriteLine("Sorting by price\n");
            
            foreach (var pet in sortedPetList)
            {
                Console.WriteLine("id: {0}\nName: {1}\nType: {2}\nBirtday: {3}\nSold date: {4}\nColor: {5}\nPrevious owner: {6}\nPrice: ${7}",
                    pet.Id, pet.Name, pet.Type, pet.BirthDay, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price);
                Console.WriteLine("------------------------------");

            }
        }
        #endregion

        #region Five Cheapest Pets code
        void GetFiveCheapestPets(List<Pet> sortedPetList)
        {
            Console.WriteLine("Sorting by price\n");
           
            foreach (var pet in sortedPetList)
            {
                Console.WriteLine("id: {0}\nName: {1}\nType: {2}\nBirtday: {3}\nSold date: {4}\nColor: {5}\nPrevious owner: {6}\nPrice: ${7}",
                    pet.Id, pet.Name, pet.Type, pet.BirthDay, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price);
                Console.WriteLine("------------------------------");

            }
        }
        #endregion

        int ShowMenu(string[] menuItems)
        {

            Console.WriteLine("Select a menu");
            Console.WriteLine("------------------------------");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine("{0}: {1}", (i + 1), menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 8)
            {
                Console.WriteLine("Your selection must be between 1-8");
            }
            
            return selection;
        }
    }
}