namespace GameInventory
{
  public class Player
  {
    public string Name { get; }
    public int MaxHealth { get; }
    public int Health { get; private set; }
    public int BaseAttack { get; }
    public int BaseDefense { get; }

    public Weapon? EquippedWeapon { get; private set; }
    public Armor? EquippedArmor { get; private set; }

    public int Attack => BaseAttack + (EquippedWeapon?.Damage ?? 0);
    public int Defense => BaseDefense + (EquippedArmor?.Defense ?? 0);

    public Player(string name, int maxHealth = 100, int baseAttack = 5, int baseDefense = 0)
    {
      Name = name;
      MaxHealth = maxHealth;
      Health = maxHealth;
      BaseAttack = baseAttack;
      BaseDefense = baseDefense;
    }

    public void EquipWeapon(Weapon weapon)
    {
      EquippedWeapon = weapon;
    }

    public void EquipArmor(Armor armor)
    {
      EquippedArmor = armor;
    }

    public void TakeDamage(int damage)
    {
      var effectiveDamage = damage - Defense;
      if (effectiveDamage < 0)
        effectiveDamage = 0;

      Health -= effectiveDamage;
      if (Health < 0)
        Health = 0;
    }

    public void Heal(int amount)
    {
      Health += amount;
      if (Health > MaxHealth)
        Health = MaxHealth;
    }
  }
}