using ConsoleRpgEntities.Models.Rooms;
using ConsoleRpgEntities.Models.UI.Menus.InteractiveMenus;
using ConsoleRpgEntities.Models.Interfaces.Rooms;

namespace ConsoleRpgEntities.Models.Dungeons;

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
