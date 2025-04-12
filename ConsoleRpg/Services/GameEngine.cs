using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Abilities;
using ConsoleRpgEntities.Models.UI;
using ConsoleRpgEntities.Models.Units.Abstracts;
using ConsoleRpgEntities.Services;

namespace ConsoleRpg.Services;

public class GameEngine
{
    private GameContext _db;
    private SeedHandler _seedHandler;
    private UserInterface _userInterface;
    private CombatHandler _combatHandler;

    public GameEngine(GameContext db, SeedHandler seedHandler, UserInterface userInterface, CombatHandler combatHandler)
    {
        _db = db;
        _seedHandler = seedHandler;
        _userInterface = userInterface;
        _combatHandler = combatHandler;
    }

    public void StartGameEngine()
    {
        Initialization();
        Run();
        //Test();
        End();
    }

    void Test()
    {
        Unit rogue = _db.Units.Where(u => u.Class == "Rogue").FirstOrDefault();
        Unit target = _db.Units.FirstOrDefault();
        Ability steal = _db.Abilities.Where(a => a.Units.Contains(rogue)).FirstOrDefault();
        rogue.UseAbility(target, steal);
        
        rogue.Attack(target);
    }

    public void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        //_unitManager.ImportUnits(); //Imports the caracters from the csv or json file.
        _seedHandler.SeedDatabase();
    }

    public void Run()
    {
        // Shows the main menu.  Allows you to add/edit characters before the game is started.
        _userInterface.MainMenu.Display("[[Start Game]]");

        //Dungeon dungeon = _dungeonFactory.CreateDungeon("intro");
        //dungeon.EnterDungeon();

        _combatHandler.StartCombat();
    }

    public void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        _userInterface.ExitMenu.Show();
    }
}
