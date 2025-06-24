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
            var context = new AnimalContext();
            var repository = new AnimalRepository(context);
            var logger = new LoggerService();

            using var client = new HttpClient();
            var api = new AnimalApiService(client,logger);

            AnimalService service = new AnimalService(repository,logger);

            ServiceMenu menu = new ServiceMenu(api,service);
            //Menu

            await menu.Menu();






        }
    }
}
