namespace GameInventory
{
  public class QuestItem : Item
  {
    public QuestItem(string name, string description = "")
        : base(name, ItemType.QuestItem, description)
    {
    }
  }
}