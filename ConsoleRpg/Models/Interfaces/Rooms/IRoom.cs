using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Rooms;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Interfaces.Rooms;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    List<Unit>? Units { get; set; }
    //List<AdjacentRoom> AdjacentRooms { get; set; }
    void OnRoomEnter(Unit unit);
    void AddAdjacentRoom(Room room, Direction direction);

}
