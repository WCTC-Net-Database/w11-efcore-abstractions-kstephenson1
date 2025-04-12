using System.Reflection;
using ConsoleRpg.Data;
using ConsoleRpg.FileIO;
using ConsoleRpg.Helpers;
using ConsoleRpg.Models.UI;
using ConsoleRpg.Models.UI.Character;
using ConsoleRpg.Models.UI.Menus;
using ConsoleRpg.Models.UI.Menus.InteractiveMenus;
using ConsoleRpg.Models.Units.Abstracts;
using ConsoleRpg.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NReco.Logging.File;

namespace ConsoleRpg;

public static class Startup
{
    public static void ConfigureConsole()
    {
        string? title = typeof(Startup).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title;
        string? version = typeof(Startup).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion.Split('+')[0];
        string? author = typeof(Startup).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyCompanyAttribute>()!.Company;
        Console.Title = $"{title} v{version} by {author}";

    }
    public static void ConfigureServices(IServiceCollection services)
    {
        // Build configuration
        var configuration = ConfigurationHelper.GetConfiguration();

        // Create and bind FileLoggerOptions
        var fileLoggerOptions = new NReco.Logging.File.FileLoggerOptions();
        configuration.GetSection("Logging:File").Bind(fileLoggerOptions);

        // Configure logging
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));

            // Add Console logger
            loggingBuilder.AddConsole();

            // Add File logger using the correct constructor
            var logFileName = "Logs/log.txt"; // Specify the log file path

            loggingBuilder.AddProvider(new FileLoggerProvider(logFileName, fileLoggerOptions));
        });

        // Register DbContext with dependency injection
        services.AddDbContext<GameContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("DbConnection"))
                .UseLazyLoadingProxies()
        );


        // Register your services
        services.AddTransient<CharacterUtilities>();
        services.AddTransient<CharacterUI>();
        services.AddTransient<CombatHandler>();
        services.AddTransient<CommandHandler>();
        services.AddTransient<CommandMenu>();
        services.AddTransient<DungeonFactory>();
        services.AddTransient<ExitMenu>();
        services.AddSingleton<FileManager<Unit>>();
        services.AddDbContext<GameContext>(options => options
        .UseSqlServer(configuration.GetConnectionString("DbConnection"))
        .UseLazyLoadingProxies());
        services.AddTransient<InventoryMenu>();
        services.AddTransient<ItemCommandMenu>();
        services.AddTransient<LevelUpMenu>();
        services.AddTransient<MainMenu>();
        services.AddTransient<RoomFactory>();
        services.AddTransient<RoomMenu>();
        services.AddTransient<RoomNavigationMenu>();
        services.AddTransient<RoomUI>();
        services.AddTransient<SeedHandler>();
        services.AddSingleton<UnitClassMenu>();
        services.AddSingleton<UnitManager>();
        services.AddTransient<UnitSelectionMenu>();
        services.AddTransient<UserInterface>();
    }
}