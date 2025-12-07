namespace GameInventory
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Player player = new Player("Рыцарь");
      Inventory inventory = new Inventory();

      Weapon sword = new Weapon("Железный меч", 10);
      Armor armor = new Armor("Кожаная броня", 3);
      Potion potion = new Potion("Маленькое зелье", 20);

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

      Console.WriteLine($"Старый меч: урон={sword.Damage}, уровень={sword.Level}");
      Console.WriteLine($"Новый меч: урон={upgradedSword.Damage}, уровень={upgradedSword.Level}");
    }
  }
}