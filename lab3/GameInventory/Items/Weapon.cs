namespace GameInventory
{
  public class Weapon : Item, IUsable, IEquippable, IUpgradeable
  {
    public int Damage { get; private set; }
    public int Level { get; private set; }

    public Weapon(string name, int damage, int level = 1, string description = "")
        : base(name, ItemType.Weapon, description)
    {
      Damage = damage;
      Level = level;
    }

    public void Use(Player player, Inventory inventory)
    {
      Equip(player);
    }

    public void Equip(Player player)
    {
      player.EquipWeapon(this);
    }

    public void Upgrade()
    {
      Level++;
      Damage += 5;
    }
  }
}
