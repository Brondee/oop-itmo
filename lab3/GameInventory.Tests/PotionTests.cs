using Xunit;

namespace GameInventory.Tests
{
  public class PotionTests
  {
    [Fact]
    public void HealsPlayerAndRemovesFromInventory()
    {
      var player = new Player("Hero", maxHealth: 100);
      player.TakeDamage(50);

      var inventory = new Inventory();
      var potion = new Potion("Small Potion", 30);

      inventory.AddItem(potion);

      potion.Use(player, inventory);

      Assert.Equal(80, player.Health);
      Assert.DoesNotContain(potion, inventory.Items);
    }
  }
}
