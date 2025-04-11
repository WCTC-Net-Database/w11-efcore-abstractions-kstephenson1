using ConsoleRPG.DataTypes;
using ConsoleRPG.Models.Rooms;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Interfaces.Rooms;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    List<Unit>? Units { get; set; }
    //List<AdjacentRoom> AdjacentRooms { get; set; }
    void OnRoomEnter(Unit unit);
    void AddAdjacentRoom(Room room, Direction direction);

}
