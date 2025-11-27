namespace GameInventory
{
  public abstract class Item : IItem
  {
    public string Name { get; protected set; }
    public ItemType Type { get; protected set; }
    public string Description { get; protected set; }

    protected Item(string name, ItemType type, string description)
    {
      Name = name;
      Type = type;
      Description = description;
    }

    public override string ToString()
    {
      return $"{Name} ({Type})";
    }
  }
}