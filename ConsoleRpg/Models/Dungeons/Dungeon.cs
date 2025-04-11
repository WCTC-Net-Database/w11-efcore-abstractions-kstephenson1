using ConsoleRPG.Models.Interfaces.Rooms;
using ConsoleRPG.Models.Rooms;
using ConsoleRPG.Models.UI.Menus.InteractiveMenus;

namespace ConsoleRPG.Models.Dungeons;

public class Dungeon
{
    public int DungeonId { get; set; }
    private RoomNavigationMenu _roomNavigationMenu;
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual Room StartingRoom { get; set; }
    public Dungeon()
    {
        
    }
    public Dungeon(RoomNavigationMenu roomNavigationMenu)
    {
        _roomNavigationMenu = roomNavigationMenu;
    }

    public void EnterDungeon()
    {
        IRoom currentRoom = StartingRoom;
        while (true)
        {
            currentRoom = _roomNavigationMenu.Display(currentRoom, "NavigationMenu", "Go Back");
        }
        
    }
}
