namespace ConsoleRpg.Models.Items.ConsumableItems;

public abstract class ConsumableItem : Item
{
    public virtual int MaxUses { get; set; }
    public virtual int UsesLeft { get; set; }
    protected ConsumableItem()
    {
        
    }

    protected ConsumableItem(string name, string desc) : base(name, desc)
    {
        
    }
}
