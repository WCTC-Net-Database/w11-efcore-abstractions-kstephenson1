using ConsoleRpgEntities.DataTypes;
using ConsoleRpgEntities.Models.Rooms;
using ConsoleRpgEntities.Models.Units.Abstracts;

namespace ConsoleRpgEntities.Models.Interfaces.Rooms;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    List<Unit>? Units { get; set; }
    //List<AdjacentRoom> AdjacentRooms { get; set; }
    void OnRoomEnter(Unit unit);
    void AddAdjacentRoom(Room room, Direction direction);

}
