namespace GameInventory
{
  public class Potion : Item, IUsable
  {
    public int HealAmount { get; private set; }

    public int Level { get; private set; }

    public Potion(string name, int healAmount, string description = "")
        : base(name, ItemType.Potion, description)
    {
      HealAmount = healAmount;
    }

    public void Use(Player player, Inventory inventory)
    {
      player.Heal(HealAmount);
      inventory.RemoveItem(this);
    }
  }
}
