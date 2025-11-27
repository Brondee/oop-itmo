namespace GameInventory
{
  public class WeaponBuilder : IWeaponBuilder
  {
    private string _name = "Unnamed";
    private int _damage = 0;
    private int _level = 1;
    private string _description = "";

    public IWeaponBuilder SetName(string name)
    {
      _name = name;
      return this;
    }

    public IWeaponBuilder SetDamage(int damage)
    {
      _damage = damage;
      return this;
    }

    public IWeaponBuilder SetLevel(int level)
    {
      _level = level;
      return this;
    }

    public WeaponBuilder SetDescription(string description)
    {
      _description = description;
      return this;
    }

    public Weapon Build()
    {
      return new Weapon(_name, _damage, _level, _description);
    }
  }
}