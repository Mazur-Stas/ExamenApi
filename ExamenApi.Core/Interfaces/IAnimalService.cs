using ExamenApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApi.Core.Interfaces;

    public interface IAnimalService
    {
        Task<IEnumerable<Animal>> GetAll();
        Task<Animal> AddAnimalAsync(Animal animal);
        Task<Animal> GetAnimalByIdAsync(int id);
        Task<Animal> UpdateAnimalAsync(Animal animal,int id);
        Task DeleteAnimalAsync(int id);
    }

