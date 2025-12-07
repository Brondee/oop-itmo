namespace GameInventory
{
  public class Armor : Item, IUsable, IEquippable
  {
    public int Defense { get; private set; }
    public int Level { get; private set; }

    public Armor(string name, int defense, int level = 1, string description = "")
        : base(name, ItemType.Armor, description)
    {
      Defense = defense;
      Level = level;
    }

    public void Equip(Player player)
    {
      player.EquipArmor(this);
    }

    public void Use(Player player, Inventory inventory)
    {
      Equip(player);
    }
  }
}
