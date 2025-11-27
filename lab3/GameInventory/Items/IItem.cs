namespace GameInventory
{
  public interface IItem
  {
    string Name { get; }
    ItemType Type { get; }
    string Description { get; }
  }
}
