namespace VendingMachine;

public class Transaction
{
  public Dictionary<int, int> InsertedCoins { get; } = new();

  public int TotalInsertedRub => InsertedCoins.Sum(kv => kv.Key * kv.Value);

  public void AddCoin(int denomRub)
  {
    if (!InsertedCoins.ContainsKey(denomRub))
      InsertedCoins[denomRub] = 0;
    InsertedCoins[denomRub]++;
  }

  public Dictionary<int, int> RefundAll()
  {
    var refund = new Dictionary<int, int>(InsertedCoins);
    InsertedCoins.Clear();
    return refund;
  }

  public void Clear() => InsertedCoins.Clear();
  public bool IsEmpty => InsertedCoins.Count == 0;
}