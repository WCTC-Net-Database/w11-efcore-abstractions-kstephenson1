using Microsoft.Extensions.DependencyInjection;
using ConsoleRPG.Data;
using ConsoleRPG.Models.UI;
using ConsoleRPG.Services;
using ConsoleRPG;
using ConsoleRPG.Data;

namespace ConsoleRPG;

class Program
{
    static void Main()
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);
        

        ServiceProvider provider = serviceCollection.BuildServiceProvider();

        GameContext db = provider.GetRequiredService<GameContext>();
        SeedHandler seedHandler = provider.GetRequiredService<SeedHandler>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();
        DungeonFactory dungeonFactory = provider.GetRequiredService<DungeonFactory>();

        GameEngine engine = new GameEngine(db, seedHandler, userInterface, dungeonFactory);
        engine.StartGameEngine();
    }
}

/*




        
 
 
 
 
 
 
 
 
 
 
 */