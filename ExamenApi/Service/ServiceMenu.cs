using ExamenApi.Core.Models;
using ExamenApi.Core.Repository;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApi.Service;

    public class ServiceMenu
    {
    public readonly AnimalApiService _animalApiService;
    public readonly AnimalService _animalService;

    public ServiceMenu()
    {
        _animalApiService = new AnimalApiService();
        _animalService = new AnimalService();
    }


    public async Task Menu()
    {
        while (true)
        {

            Console.WriteLine("=========== DataBase ===========");
            Console.WriteLine("1. Add new animal ");
            Console.WriteLine("2. Update animal ");
            Console.WriteLine("3. Delete animal ");
            Console.WriteLine("4. Search animal by Id ");
            Console.WriteLine("5. Show all animals ");
            Console.WriteLine("============= Api =============");
            Console.WriteLine("6. Get all animals ");
            Console.WriteLine("7. Get animal by name ");
            Console.WriteLine("8. Get animal by country code ");
            Console.WriteLine("9. Sort by name ");
            Console.WriteLine("10. Show all animals from DataBase and Api");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Enter Scientific Name of animal:");
                    string scientificName1 = Console.ReadLine();

                    Console.WriteLine("Enter Conservation Status  of animal:");
                    string conservationStatus1 = Console.ReadLine();

                    Console.WriteLine("Enter Group Name  of animal:");
                    string groupName1 = Console.ReadLine();

                    Console.WriteLine("Enter Country Code  of animal:");
                    string countryCode1 = Console.ReadLine();

                    Console.WriteLine("Enter Common Name  of animal:");
                    string commonName1 = Console.ReadLine();

                    var animal1 = new Animal
                    {
                        ScientificName = scientificName1,
                        ConservationStatus = conservationStatus1,
                        GroupName = groupName1,
                        CountryCode = countryCode1,
                        CommonName = commonName1
                    };
                    await _animalService.AddAnimalAsync(animal1);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter id of animal to update:");
                    var id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter new Scientific Name of animal:");
                    string scientificName2 = Console.ReadLine();

                    Console.WriteLine("Enter new Conservation Status  of animal:");
                    string conservationStatus2 = Console.ReadLine();

                    Console.WriteLine("Enter new Group Name  of animal:");
                    string groupName2 = Console.ReadLine();

                    Console.WriteLine("Enter new Country Code  of animal:");
                    string countryCode2 = Console.ReadLine();

                    Console.WriteLine("Enter new Common Name  of animal:");
                    string commonName2 = Console.ReadLine();

                    var animal2 = new Animal
                    {
                        ScientificName = scientificName2,
                        ConservationStatus = conservationStatus2,
                        GroupName = groupName2,
                        CountryCode = countryCode2,
                        CommonName = commonName2
                    };
                    await _animalService.UpdateAnimalAsync(animal2, id);
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter id of animal to delete:");
                    var idDel = int.Parse(Console.ReadLine());

                    await _animalService.DeleteAnimalAsync(idDel);
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter id of animal to search:");
                    var idSearch = int.Parse(Console.ReadLine());

                    Animal an4 = await _animalService.GetAnimalByIdAsync(idSearch);
                    await _animalService.ShowAnimal(an4);
                    break;

                case "5":
                    Console.Clear();
                    List<Animal> animals = (await _animalService.GetAll()).ToList();
                    foreach (Animal an in animals)
                    {

                       await _animalService.ShowAnimal(an);
                    }
                    break;
                case "6":
                    Console.Clear();
                    List<Animal> animals1 = (await _animalApiService.GetAllAsync()).ToList();
                    foreach (Animal an in animals1)
                    {

                        await _animalService.ShowAnimal(an);
                    }
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("Enter name of animal to search:");
                    string name = Console.ReadLine();

                    Animal an6 = await _animalApiService.SearchByNameAsync(name);
                    await _animalService.ShowAnimal(an6);
                    break;

                case "8":
                    Console.Clear();
                    Console.WriteLine("Enter country code of animal to search:");
                    string code = Console.ReadLine();

                    List<Animal> animals6 = await _animalApiService.GetByCountryCodeAsync(code);
                    foreach(Animal an in animals6) 
                    {
                        await _animalService.ShowAnimal(an);
                    }

                    break;

                case "9":
                    Console.Clear();
                    Console.WriteLine("\nSorted by name:");
                    var sorted = await _animalApiService.GetSortedAsync();
                    foreach (var a in sorted)
                    {
                        Console.WriteLine(a.CommonName); 
                    }
                    break;

                case "10":
                    Console.Clear();
                    List<Animal> animalsDB = (await _animalService.GetAll()).ToList();
                    List<Animal> animalsAPI = (await _animalApiService.GetAllAsync()).ToList();
                    animalsDB.AddRange(animalsAPI);

                    foreach (Animal an in animalsDB)
                    {

                        await _animalService.ShowAnimal(an);
                    }
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }

    }
