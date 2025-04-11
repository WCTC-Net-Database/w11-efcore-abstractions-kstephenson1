
using System.ComponentModel.DataAnnotations;
using ConsoleRPG.DataTypes;

namespace ConsoleRPG.Models.Rooms;

public class AdjacentRoom
{
    [Key]
    public Room Room { get; set; }

    [Key]
    public Direction Direction { get; set; }

    public AdjacentRoom()
    {
        
    }

    public AdjacentRoom(Room room, Direction direction)
    {
        Room = room;
        Direction = direction;
    }
}
