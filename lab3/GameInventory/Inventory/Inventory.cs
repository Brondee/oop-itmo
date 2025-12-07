namespace GameInventory
{
  public class Inventory
  {
    public List<IItem> Items { get; private set; } = new List<IItem>();

    public void AddItem(IItem item)
    {
      if (item == null) throw new ArgumentNullException(nameof(item));
      Items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
      Items.Remove(item);
    }

    public List<IItem> GetItemsByType(ItemType type)
    {
      return Items.Where(i => i.Type == type).ToList();
    }

    public IItem? FindByName(string name)
    {
      return Items.FirstOrDefault(i => i.Name == name);
    }
  }
}