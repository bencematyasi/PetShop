using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data.Reporsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp
{
    public class Printer
    {
        #region Repository area
        private IPetRepository petRepository;
        #endregion

        #region Printer constructor
        public Printer()    
        {
            petRepository = new PetRepository();
            InitData();
            StartUI();
        }
        #endregion

        #region InitDat method, move to AplicationService
        void InitData()
        {
            Pet brunoDoggy = new Pet
            {
                Name = "Bruno",
                Type = "dog",
                BirthDay = new DateTime(2010, 10, 05),
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
        #endregion

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
                        //List all the pets
                        var pets = GetAllPets();
                        ListAllPets(pets);
                        break;
                    case 2:
                        //Searched By Type
                        var input = AskQuestion("Search by Type\nEnter the searched type: ");
                        var  searchedType = SearchType(input);
                        GetSearchedType(searchedType);
                        break;
                    case 3:
                        //CreatPet
                        string name = AskQuestion("Enter Name: ");
                        string type = AskQuestion("Enter Type: ");
                        DateTime bithday = DateTime.Parse(AskQuestion("Enter Birthday: "));
                        DateTime soldDate = DateTime.Parse(AskQuestion("Enter Sold Date: "));
                        string color = AskQuestion("Enter color: ");
                        string previousOwner = AskQuestion("Enter Previous Owner of " + name);
                        double price = Convert.ToDouble("Enter The Price");
                        var pet = CreatePet(name, type, bithday, soldDate, color, previousOwner, price);
                        SavePet(pet);
                        break;
                    case 4:
                        //Update pet
                        Console.Clear();
                        var id = PrintFindPetById();
                        var onePet = FindPetById(id);
                        GetOneId(onePet);
                        Console.WriteLine("Updating {0}\n",onePet.Name);
                        string newName = AskQuestion("Enter Name: ");
                        string newType = AskQuestion("Enter Type: ");
                        DateTime newBirthday = DateTime.Parse(AskQuestion("Enter Birthday: "));
                        DateTime newSoldDate = DateTime.Parse(AskQuestion("Enter Sold Date: "));
                        string newColor = AskQuestion("Enter color: ");
                        string newPreviousOwner = AskQuestion("Enter Previous Owner of " + newName);
                        double newPrice = Convert.ToDouble(AskQuestion("Enter The Price"));
                        UpdatePet(id,newName,newType, newBirthday, newSoldDate,newColor,newPreviousOwner,newPrice);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Delete a Pet\n");
                        var idForDelete = PrintFindPetById();
                        var petDelete = FindPetById(idForDelete);
                        Console.WriteLine("{0} will be deleted\n", petDelete.Name);
                        DeletePet(idForDelete);
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

        Pet FindPetById(int id)
        {
            return petRepository.ReadById(id);
        }

        #region List Pets code
        List<Pet>  GetAllPets()
        {
            return petRepository.ReadAll();
        }
        void ListAllPets(List<Pet> listOfPets)
        {
            Console.Clear();
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

        List<Pet> SearchType(string input)
        {
            List<Pet> pets = petRepository.ReadAll();
            List<Pet> typeSeacrhes = pets.FindAll(p => p.Type == input);
            return typeSeacrhes;
        }
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

        string AskQuestion(string question)
        {
           
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        #region Create Pet code
        Pet CreatePet(string name, string type, DateTime birthday, DateTime soldDate, string color, string previousOwner, double price)
        {
            Console.Clear();
            Console.WriteLine("Add a Pet\n");

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

        Pet SavePet(Pet pet)
        {
            return petRepository.Creat(pet);
        }
        #endregion

        #region Update Pet code

        Pet GetOneId(Pet onePet)
        {
            var pet = petRepository.ReadOne(onePet.Id);
            return pet;
        }

        void UpdatePet(int id, string newName, string newType, DateTime newBirthday, DateTime newSoldDate, string newColor, string newPreviousOwner, double newPrice)
        {
            Console.Clear();
            Console.WriteLine("Update a Pet\n");
            var pet = FindPetById(id);
            pet.Name = newName;
            pet.Type = newType;
            pet.BirthDay = newBirthday;
            pet.SoldDate = newSoldDate;
            pet.Color = newColor;
            pet.PreviousOwner = newPreviousOwner;
            pet.Price = newPrice;
        }
        #endregion

        #region Delete pet code
        void DeletePet(int idForDelete)
        {
            petRepository.Delete(idForDelete);
        }
        #endregion

        void SortPetByPrice()
        {
                //Console.Clear();
                //Console.WriteLine("Sorting by price\n");
                //List<Pet> sortedPetList = ;
                //sortedPetList = GetOrderList()
                //sortedPetList.OrderBy(p => p.Price).ToList();

                //foreach (var pet in sortedPetList)
                //{
                //    Console.WriteLine("id: {0}\nName: {1}\nType: {2}\nBirtday: {3}\nSold date: {4}\nColor: {5}\nPrevious owner: {6}\nPrice: ${7}",
                //        pet.Id, pet.Name, pet.Type, pet.BirthDay, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price);
                //    Console.WriteLine("------------------------------");

                throw new NotImplementedException();
            }
       
        void GetFiveCheapestPets()
        {
            throw new NotImplementedException();
        }
            

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