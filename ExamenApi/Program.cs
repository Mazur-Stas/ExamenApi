using ExamenApi.Service;
using ExamenApi.Core;
using ExamenApi.Storage;
using ExamenApi.Core.Models;
using System.Threading.Tasks;
using ExamenApi.Storage.Repository;
namespace ExamenApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ServiceMenu menu = new ServiceMenu();

            await menu.Menu();






        }
    }
}
