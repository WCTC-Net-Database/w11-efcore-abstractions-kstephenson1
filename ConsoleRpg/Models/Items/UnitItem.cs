using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Units.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey("UnitId", "ItemId")]
public class UnitItem
{
    //[Key]
    //public int UnitItemId { get; set; }

    [ForeignKey("Unit")]
    public int UnitId { get; set; }
    public virtual Unit Unit { get; set; }

    [ForeignKey("Item")]
    public int ItemId { get; set; }
    public virtual Item Item { get; set; }
    public virtual EquipmentSlot Slot { get; set; } = EquipmentSlot.None;
    public virtual int Quantity { get; set; }
}