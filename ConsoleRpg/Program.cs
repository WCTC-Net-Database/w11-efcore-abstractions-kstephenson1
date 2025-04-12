using ConsoleRpg.Data;
using ConsoleRpg.Models.UI;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleRpg;

class Program
{
    static void Main()
    {
        Startup.ConfigureConsole();
        ServiceCollection serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);
        

        ServiceProvider provider = serviceCollection.BuildServiceProvider();

        GameContext db = provider.GetRequiredService<GameContext>();
        SeedHandler seedHandler = provider.GetRequiredService<SeedHandler>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();

        GameEngine engine = new GameEngine(db, seedHandler, userInterface);
        engine.StartGameEngine();
    }
}

/*




        
 
 
 
 
 
 
 
 
 
 
 */