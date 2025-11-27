namespace GameInventory
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var player = new Player("Hero");
      var inventory = new Inventory();

      var sword = new Weapon("Iron Sword", 10);
      var armor = new Armor("Leather Armor", 3);
      var potion = new Potion("Small Potion", 20);

      inventory.AddItem(sword);
      inventory.AddItem(armor);
      inventory.AddItem(potion);

      Console.WriteLine("Начальный инвентарь:");
      foreach (var item in inventory.Items)
      {
        Console.WriteLine(item);
      }

      sword.Use(player, inventory);
      armor.Use(player, inventory);
      potion.Use(player, inventory);

      Console.WriteLine($"Атака: {player.Attack}, Защита: {player.Defense}, Здоровье: {player.Health}");

      var upgradeService = new ItemUpgradeService(new WeaponBuilder());
      var upgradedSword = upgradeService.UpgradeWeapon(sword);

      Console.WriteLine($"Старый меч: dmg={sword.Damage}, level={sword.Level}");
      Console.WriteLine($"Новый меч: dmg={upgradedSword.Damage}, level={upgradedSword.Level}");
    }
  }
}