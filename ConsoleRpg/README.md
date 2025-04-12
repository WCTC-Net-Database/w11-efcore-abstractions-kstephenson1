### Assignment: Implement Table-per-hierarchy (TPH) and discriminator in Entity Framework

**Objective:**  
In this assignment, you will be introduced to Entity Framework (EF) Core and use it to manage your `Room` and `Character` entities within the Console RPG project. You will learn how to set up the Entity Framework context, work with connection strings, generate migrations, and update the database. Additionally, you will be required to implement functionality to add and find characters using the `GameEngine` and `Menu` classes. You will also extend the project to include a new `Ability` entity and ensure that both `Player` and `Goblin` classes can have multiple abilities.

---

### **Instructions:**

#### Step 1: Setup Entity Framework Core

Ensure your project references EF Core by installing the necessary packages. Use the following commands in the **Package Manager Console** or the **.NET CLI**:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 6.0.35
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.35
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.35
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables --version 6.0.1
dotnet add package Microsoft.Extensions.Configuration.Json --version 6.0.0
dotnet add package Microsoft.Extensions.Logging.Console --version 6.0.0
dotnet add package NReco.Logging.File --version 1.2.1

```

#### Step 2: Update `GameContext.cs`

Modify the `GameContext` class to include the correct EF Core connection string and define the `DbSet` properties for your `Room`, `Character`, and `Ability` entities.

```csharp
using Microsoft.EntityFrameworkCore;

public class GameContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Ability> Abilities { get; set; }

    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure TPH for Character hierarchy
        modelBuilder.Entity<Character>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Player>("Player")
            .HasValue<Goblin>("Goblin");

        // TODO Configure TPH for Abilities hierarchy

        // Configure many-to-many relationship between Character and Ability
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Abilities)
            .WithMany(a => a.Characters)
            .UsingEntity(j => j.ToTable("CharacterAbilities"));

        base.OnModelCreating(modelBuilder);
    }
}
```

You can find the correct connection string format on [Connection Strings](https://www.connectionstrings.com/sql-server/). Choose the connection string that corresponds to your SQL Server setup.

#### Step 3: Generate Migrations

**Verify Installation**

To verify that the correct packages have been installed, execute the following command in the terminal:
```bash
dotnet list package
```

This will list all installed packages, including `Microsoft.EntityFrameworkCore.SqlServer` and `Microsoft.EntityFrameworkCore.Tools`.

---

**Verify EF Core CLI Tools**

Ensure you have installed the EF Core tools globally:

```bash
dotnet tool install --global dotnet-ef
```

**Verify the installation by running:**

```bash
dotnet ef
```

If correctly installed, this will show the EF Core tool commands.

---

**Generate Migrations**

Once everything is set up, generate migrations by running:

```bash
dotnet ef migrations add InitialCreate
```

This creates the first migration file in the project and prepares the database schema for use.

#### Step 4: Update the Database

After generating the migration, apply the changes to the database by running:

```bash
dotnet ef database update
```

This will create the `Rooms`, `Characters`, and `Abilities` tables in your SQL Server database.

#### Step 5: Verify the Template Is Running

Before proceeding to the next steps, verify that your base assignment template is working correctly by running the application. It should not throw any errors, and you should be able to interact with the `GameContext` for simple read/write operations.

---

### **Modification Requirements:**

#### 1. Add Abilities

Extend the project to include a new `Ability` entity and ensure that both `Player` and `Goblin` classes can have multiple abilities.

**Ability.cs:**
```csharp
public abstract class Character : ICharacter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }

    // Foreign key to Room
    public int RoomId { get; set; }

    // Navigation property to Room
    public virtual Room Room { get; set; }

    // Navigation property to Abilities
    public virtual ICollection<Ability> Abilities { get; set; }

    public virtual void Attack(ICharacter target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}!");
    }
}

public abstract class Ability
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation property to Characters
    public virtual ICollection<Character> Characters { get; set; }
}
```

**PlayerAbility.cs:**
```csharp
public class PlayerAbility : Ability
{
    public int Shove { get; set; }
}
```

**GoblinAbility.cs:**
```csharp
public class GoblinAbility : Ability
{
    public int Taunt { get; set; }
}
```

**Update `GameContext.cs` to include the new `Ability` entity:**
```csharp
public DbSet<Ability> Abilities { get; set; }
```

**Generate and Apply Migrations:**
1. Generate the first migration to add the `Ability` entity:
   ```bash
   dotnet ef migrations add AddAbilitiesTable
   ```

2. Apply the migration:
   ```bash
   dotnet ef database update
   ```

3. Generate the second migration to populate some abilities:
   ```bash
   dotnet ef migrations add SeedAbilities
   ```

4. Apply the migration:
   ```bash
   dotnet ef database update
   ```

---

### **Stretch Goal (Optional, +10%):**

Implement functionality to **Execute an Ability** in the `Character` class. This should allow characters to use their abilities during gameplay.  Provide a simple call to this method during the attack sequence.

**Character.cs:**
```csharp
public virtual void ExecuteAbility(Ability ability)
{
    Console.WriteLine($"{Name} uses {ability.Name}!");
}
```

---

### **Grading Rubric (100 points total)**

- **0%** if the program doesn’t compile or run.
- **20%** if the program compiles and runs but lacks significant functionality.
- **40%** if the program compiles, runs, and partially meets the requirements but has missing or incorrect logic.
- **60%** if the program compiles, runs, and meets the base requirements:
  - Menu options are available for adding a room and adding a character.
  - The database has been seeded correctly.
  - Characters and rooms can be added and saved to the database.
- **80%** if the program compiles, runs, and meets all requirements, including:
  - Characters can be correctly found and displayed based on user input.
  - Connection string is properly configured.
  - Migrations have been successfully generated and applied.
  - Base program functionality is tested, and no significant bugs exist.
- **100%** if the program compiles, runs, and meets all requirements, with:
  - Clear, concise code and appropriate use of comments.
  - Well-structured, clean code adhering to best practices, including using Entity Framework Core effectively.

---



### References

[Entity Framework Core Inheritance](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance)
