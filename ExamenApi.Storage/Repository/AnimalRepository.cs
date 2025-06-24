using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenApi.Core.Models;
using ExamenApi.Core.Repository;
using Microsoft.EntityFrameworkCore;
namespace ExamenApi.Storage.Repository;

public class AnimalRepository : IAnimalRepository
{
    private readonly AnimalContext  _context;

    public AnimalRepository()
    {
        _context = new AnimalContext();
    }
    public AnimalRepository(AnimalContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Animal>> GetAll()
    {
        return await _context.Animals.ToListAsync();
    }
    public async Task<Animal> AddAnimalAsync(Animal animal)
    {
        _context.Animals.Add(animal);

        await _context.SaveChangesAsync();

        return animal;
    }

    public async Task<Animal> GetAnimalByIdAsync(int id)
    {
       Animal animal = _context.Animals.FirstOrDefault(b => b.Id == id);


        return animal;
    }

    public async Task<Animal> UpdateAnimalAsync(Animal animal) 
    {
        _context.Animals.Update(animal);

        await _context.SaveChangesAsync();
        return animal;
    }
    public async Task<Animal> DeleteAnimalAsync(Animal animal)
    {
        _context.Animals.Remove(animal);

        await _context.SaveChangesAsync();
        return animal;
    }
}

