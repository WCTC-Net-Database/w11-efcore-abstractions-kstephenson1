using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items.EquippableItems.WeaponItems;

namespace ConsoleRpg.Models.Combat;

public class Encounter
{
    // The encounter class is used to store and calculate information about combat encounters.  This object takes in an attacking attackingUnit,
    // defendingUnit attackingUnit and will be able to generate combat chances and damages.

    private Random _generator = new Random();
    private Dictionary<Tuple<WeaponType, WeaponType>, int> dict = new();
    public int Roll;
    public IUnit Unit { get; set; }
    public IUnit Target { get; set; }
    public Stat Stat { get; set; }
    public int Damage => RollDamage();

    public Encounter(IUnit unit, IUnit target)
    {
        Roll = _generator.Next(100) + 1;
        Unit = unit;
        Target = target;

        try
        {
            Unit.Inventory.HasWeaponEquipped();
            Target.Inventory.HasWeaponEquipped();
        }
        catch
        {
            return;
        }

        Tuple<WeaponType, WeaponType> swordVsAxe = new(WeaponType.Sword, WeaponType.Axe);
        Tuple<WeaponType, WeaponType> swordVsLance = new(WeaponType.Sword, WeaponType.Lance);
        Tuple<WeaponType, WeaponType> axeVsSword = new(WeaponType.Axe, WeaponType.Sword);
        Tuple<WeaponType, WeaponType> axeVsLance = new(WeaponType.Axe, WeaponType.Lance);
        Tuple<WeaponType, WeaponType> LanceVsSword = new(WeaponType.Lance, WeaponType.Sword);
        Tuple<WeaponType, WeaponType> LanceVsAxe = new(WeaponType.Lance, WeaponType.Axe);

        Tuple<WeaponType, WeaponType> eleVsLight = new(WeaponType.Elemental, WeaponType.Light);
        Tuple<WeaponType, WeaponType> eleVsDark = new(WeaponType.Elemental, WeaponType.Dark);
        Tuple<WeaponType, WeaponType> lightVsEle = new(WeaponType.Light, WeaponType.Elemental);
        Tuple<WeaponType, WeaponType> lightVsDark = new(WeaponType.Light, WeaponType.Dark);
        Tuple<WeaponType, WeaponType> darkVsEle = new(WeaponType.Dark, WeaponType.Elemental);
        Tuple<WeaponType, WeaponType> darkVsLight = new(WeaponType.Dark, WeaponType.Light);

        dict.Add(swordVsAxe, 1);
        dict.Add(axeVsLance, 1);
        dict.Add(LanceVsSword, 1);
        dict.Add(swordVsLance , -1);
        dict.Add(LanceVsAxe, -1);
        dict.Add(axeVsSword , -1);

        dict.Add(eleVsLight , 1);
        dict.Add(lightVsDark, 1);
        dict.Add(darkVsEle, 1);
        dict.Add(eleVsDark , -1);
        dict.Add(darkVsLight, -1);
        dict.Add(lightVsEle , -1);
    }


    public int RollDamage()
    {
        if (IsCrit())
        {
            if (Unit.Inventory.EquippedWeapon is PhysicalWeaponItem)
            {
                return (int)MathF.Max(GetDamage(), 0) + (int)MathF.Max(GetDamage(), 0);
            }
            else if (Unit.Inventory.EquippedWeapon is MagicWeaponItem)
            {
                return (int)MathF.Max(GetMagicDamage(), 0) + (int)MathF.Max(GetMagicDamage(), 0);
            }
            
        }
        else if (IsHit())
        {
            if (Unit.Inventory.EquippedWeapon is PhysicalWeaponItem)
            {
                return (int)MathF.Max(GetDamage(), 0);
            }
            else if (Unit.Inventory.EquippedWeapon is MagicWeaponItem)
            {
                return (int)MathF.Max(GetMagicDamage(), 0);
            }
        }
        return 0;
    }

    public bool IsCrit()
    {
        bool crit = Roll > MathF.Abs(GetDisplayedCrit() - 100) ? true : false;
        return crit;
    }

    public bool IsHit()
    {
        bool hit = Roll > MathF.Abs(GetDisplayedHit() - 100) ? true : false;
        return hit;
    }

    public int GetTriangleDamageModifier()
    {

        if (Unit.Inventory.EquippedWeapon == null || Target.Inventory.EquippedWeapon == null) return 0;

        Tuple<WeaponType,WeaponType> weapons = new(Unit.Inventory.EquippedWeapon.WeaponType, Target.Inventory.EquippedWeapon.WeaponType);
        dict.TryGetValue(weapons, out int value);
        if (value != 0) return value;
        return 0;
    }

    public int GetTriangleHitModifier()
    {
        return GetTriangleDamageModifier() * 15;
    }

    public int GetAttack()
    {
        // Attack damage = Attacking unit's strength + (Equipped item's might + bonus if the weapon type has an advantage against the defender's)
        int weaponEfficiency = 1; // for future implementation?
        return Unit.Stat.Strength + weaponEfficiency * (Unit.Inventory.EquippedWeapon.Might + GetTriangleDamageModifier());
    }

    public int GetMagicAttack()
    {
        // Attack damage = Attacking unit's magic + (Equipped item's might + bonus if the weapon type has an advantage against the defender's)
        int weaponEfficiency = 1; // for future implementation?
        return Unit.Stat.Magic + weaponEfficiency * (Unit.Inventory.EquippedWeapon.Might + GetTriangleDamageModifier());
    }

    public int GetPhysicalResiliance(IUnit unit)
    {
        // Physical Resiliance = unit's Defense stat
        int terrainBonus = 1; // for future implementation?
        return unit.Stat.Defense * terrainBonus;
    }

    public int GetMagicResiliance(IUnit unit)
    {
        // Magic Resiliance = Resistance stat
        int terrainBonus = 1; // for future implementation?
        return unit.Stat.Resistance * terrainBonus;
    }

    public int GetDamage()
    {
        // Damage = Attacking Unit's Attack minus Defending Unit's Physical Resiliance
        return GetAttack() - GetPhysicalResiliance(Target);
    }

    public int GetMagicDamage()
    {
        // Damage = Attacking Unit's Attack minus Defending Unit's Physical Resiliance
        return GetMagicAttack() - GetMagicResiliance(Target);
    }

    public int GetAttackSpeed()
    {
        // Attack speed = speed - (weapon's weight - unit's constitution [min 0])
        return Unit.Stat.Speed - (int)MathF.Max(Unit.Inventory.EquippedWeapon.Weight - Unit.Stat.Constitution, 0);
    }

    public int GetHit()
    {
        // Hit chance = weapon's hit + 2 x attacking unit's DEX + attacking unit's LCK / 2 + weapon advantage modifier of 15%
        return Unit.Inventory.EquippedWeapon.Hit + 2 * Unit.Stat.Dexterity + Unit.Stat.Luck / 2 + GetTriangleHitModifier();
    }

    public int GetAvoid()
    {
        // Avoid = 2 * Atk Speed + Luck + Terrain Modifier
        int terrainAvoidModifier = 0;// for future implementation?
        return 2 * GetAttackSpeed() + Unit.Stat.Luck + terrainAvoidModifier;
    }

    public int GetDisplayedHit()
    {
        return GetHit() - GetAvoid();
    }

    public int GetCrit()
    {
        return Unit.Inventory.EquippedWeapon.Crit + Unit.Stat.Dexterity * 2;
    }

    public int GetCritAvoid()
    {
        return Unit.Stat.Luck;
    }

    public int GetDisplayedCrit()
    {
        return GetHit() / 100 * GetCrit();
    }
}
