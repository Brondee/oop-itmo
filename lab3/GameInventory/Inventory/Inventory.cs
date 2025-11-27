namespace GameInventory
{
  public class Inventory
  {
    private readonly List<IItem> _items = new List<IItem>();

    public IReadOnlyCollection<IItem> Items => _items.AsReadOnly();

    public void AddItem(IItem item)
    {
      if (item == null) throw new ArgumentNullException(nameof(item));
      _items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
      _items.Remove(item);
    }

    public IEnumerable<IItem> GetItemsByType(ItemType type)
    {
      return _items.Where(i => i.Type == type);
    }

    public IItem? FindByName(string name)
    {
      return _items.FirstOrDefault(i => i.Name == name);
    }
  }
}