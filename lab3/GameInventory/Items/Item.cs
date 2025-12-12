namespace GameInventory
{
  public abstract class Item : IItem
  {
    public string Name { get; }
    public ItemType Type { get; }
    public string Description { get; }

    public Item(string name, ItemType type, string description)
    {
      Name = name;
      Type = type;
      Description = description;
    }
  }
}