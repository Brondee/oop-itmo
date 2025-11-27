namespace GameInventory
{
  public interface IUpgradeable
  {
    int Level { get; }
    void Upgrade();
  }
}