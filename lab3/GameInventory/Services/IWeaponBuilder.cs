namespace GameInventory
{
  public interface IWeaponBuilder
  {
    IWeaponBuilder SetName(string name);
    IWeaponBuilder SetDamage(int damage);
    IWeaponBuilder SetLevel(int level);
    Weapon Build();
  }
}