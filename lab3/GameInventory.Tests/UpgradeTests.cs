using Xunit;
using GameInventory;

public class UpgradeTests
{
  [Fact]
  public void IncreasesDamageAndLevel()
  {
    var weapon = new Weapon("Sword", damage: 10, level: 1);
    var builder = new WeaponBuilder();
    var service = new ItemUpgradeService(builder);

    var upgraded = service.UpgradeWeapon(weapon);

    Assert.Equal(15, upgraded.Damage);
    Assert.Equal(2, upgraded.Level);
    Assert.Equal(weapon.Name, upgraded.Name);
  }
}
