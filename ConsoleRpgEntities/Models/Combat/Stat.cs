﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpgEntities.Models.Units.Abstracts;

namespace ConsoleRpgEntities.Models.Combat;

public class Stat
{
    // Stat is a class that holds the stats of a unit.

    [Key, ForeignKey("Unit")]
    public int UnitId { get; set; }

    // Navigation
    public virtual Unit Unit { get; set; }

    // Health Stats
    public int HitPoints  { get; set; }         //  HP
    public int MaxHitPoints { get; set; }       // MHP
    public int Movement { get; set; }           // MOV

    // Primary Stats
    public int Constitution { get; set; }       // CON
    public int Strength { get; set; }           // STR
    public int Magic { get; set; }              // MAG
    public int Dexterity { get; set; }          // DEX
    public int Speed { get; set; }              // SPD
    public int Luck { get; set; }               // LCK
    public int Defense { get; set; }            // DEF
    public int Resistance { get; set; }         // RES

    public Stat() { }
}