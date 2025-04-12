using System.Reflection;
using ConsoleRpg.Services;
using ConsoleRpgEntities.Configuration;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.UI;
using ConsoleRpgEntities.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleRpg;

class Program
{
    static void Main()
    {
        string? title = typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title;
        string? version = typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion.Split('+')[0];
        string? author = typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyCompanyAttribute>()!.Company;
        Console.Title = $"{title} v{version} by {author}";

        ServiceCollection serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);
        

        ServiceProvider provider = serviceCollection.BuildServiceProvider();

        GameContext db = provider.GetRequiredService<GameContext>();
        SeedHandler seedHandler = provider.GetRequiredService<SeedHandler>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();
        CombatHandler combatHandler = provider.GetRequiredService<CombatHandler>();

        GameEngine engine = new GameEngine(db, seedHandler, userInterface, combatHandler);
        engine.StartGameEngine();
    }
}

/*




        
 
 
 
 
 
 
 
 
 
 
 */