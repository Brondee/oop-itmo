using Xunit;
using GameInventory;

public class InventoryTests
{
  [Fact]
  public void IncreasesItemsCount()
  {
    var inventory = new Inventory();
    var sword = new Weapon("Sword", 10);

    inventory.AddItem(sword);

    Assert.Single(inventory.Items);
    Assert.Contains(sword, inventory.Items);
  }

  [Fact]
  public void RemovesItemFromInventory()
  {
    var inventory = new Inventory();
    var sword = new Weapon("Sword", 10);

    inventory.AddItem(sword);
    inventory.RemoveItem(sword);

    Assert.Empty(inventory.Items);
  }

  [Fact]
  public void ReturnsOnlyRequestedType()
  {
    var inventory = new Inventory();
    inventory.AddItem(new Weapon("Sword", 10));
    inventory.AddItem(new Armor("Armor", 3));
    inventory.AddItem(new Potion("Potion", 20));

    var weapons = inventory.GetItemsByType(ItemType.Weapon);

    Assert.Single(weapons);
  }
}

