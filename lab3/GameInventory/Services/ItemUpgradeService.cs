namespace GameInventory
{
  public class ItemUpgradeService
  {
    private IWeaponBuilder _weaponBuilder;

    public ItemUpgradeService(IWeaponBuilder weaponBuilder)
    {
      _weaponBuilder = weaponBuilder;
    }

    public Weapon UpgradeWeapon(Weapon source)
    {
      var newDamage = source.Damage + 5;
      var newLevel = source.Level + 1;

      return _weaponBuilder
          .SetName(source.Name)
          .SetDamage(newDamage)
          .SetLevel(newLevel)
          .Build();
    }
  }
}