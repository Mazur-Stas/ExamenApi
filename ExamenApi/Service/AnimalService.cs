using ExamenApi.Core.Repository;
using ExamenApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using ExamenApi.Storage.Repository;

namespace ExamenApi.Service;

    public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly LoggerService _logger;

    public AnimalService()
    {
        _animalRepository = new AnimalRepository();
        _logger = new LoggerService();
    }
    public AnimalService(IAnimalRepository animalRepository, LoggerService logger)
    {
        _animalRepository = animalRepository;
        _logger = logger;
    }
    public async Task<IEnumerable<Animal>> GetAll()
    {
        _logger.Info($"Get all animals");
        var animals = await _animalRepository.GetAll();

        return  animals.ToList();
    }
  
    public async Task<Animal> AddAnimalAsync(Animal animal)
    {
        if (animal == null)
        {
            _logger.Warn("Try to add animal with null-argument.");
            throw new ArgumentException("Name cannot be null or empty");
        }
        _logger.Info($"Add animal: {animal.CommonName}");
        return await _animalRepository.AddAnimalAsync(animal);
    }

    public async Task<Animal> GetAnimalByIdAsync(int id) 
    {
        _logger.Info($"Search animal with ID: {id}");
        var an = _animalRepository.GetAnimalByIdAsync(id);

        if(an == null)
        {
            _logger.Warn("Try to add animal with null-argument.");
            throw new ArgumentException("Name cannot be null or empty");
        }

        return await an;

    }
    public async Task<Animal> UpdateAnimalAsync(Animal animal, int id)
    {

        Animal existingAnimal = await _animalRepository.GetAnimalByIdAsync(id);
        if (existingAnimal != null)
        {
            existingAnimal.ScientificName = animal.ScientificName;
            existingAnimal.CommonName = animal.CommonName;
            existingAnimal.ConservationStatus = animal.ConservationStatus;
            existingAnimal.CountryCode = animal.CountryCode;
            existingAnimal.GroupName = animal.GroupName;

            _logger.Info($"Animal with ID {id} success update");
            return await _animalRepository.UpdateAnimalAsync(existingAnimal);
        }
        else
        {
            _logger.Warn($"Тварина з ID {id} not founded");
            throw new InvalidOperationException("Animal not found.");
        }


    }
    public async Task DeleteAnimalAsync(int id)
    {
        var an = await _animalRepository.GetAnimalByIdAsync(id);

        if (an != null)
        {
            await _animalRepository.DeleteAnimalAsync(an);
            _logger.Info($"Animal with ID {id} deleted");
        }
        else
        {
            _logger.Warn($"Animal with ID {id} not found");
        }
    }

    public async Task ShowAnimal(Animal animal)
    {
        Console.WriteLine($"Id: {animal.Id} \n Scientific Name: {animal.ScientificName} \n" +
            $" Conservation Status: {animal.ConservationStatus} \n Group Name: {animal.GroupName} \n " +
            $"Country Code: {animal.CountryCode} \n Common Name: {animal.CommonName} \n");
    }
}
