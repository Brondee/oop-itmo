namespace VendingMachine;

public class VendingMachine
{
  public static readonly int[] AcceptedDenominations = { 500, 200, 100, 50, 10 };

  private readonly Dictionary<string, Product> _products = new(StringComparer.OrdinalIgnoreCase);
  private readonly Dictionary<int, int> _coinBank = AcceptedDenominations.ToDictionary(d => d, d => 0);
  private readonly Transaction _transaction = new();
  private int _revenueRub;
  private readonly string _adminPin;

  public VendingMachine(string adminPin = "1234") { _adminPin = adminPin; }

  public void AddProduct(Product p) => _products[p.Code] = p;
  public IEnumerable<Product> ListProducts() => _products.Values.OrderBy(p => p.Code);
  public int CurrentInsertedRub => _transaction.TotalInsertedRub;
  public void InsertCoin(int denom)
  {
    if (!AcceptedDenominations.Contains(denom))
      throw new ArgumentException("Номинал не принимается.");
    _transaction.AddCoin(denom);
  }
  public Dictionary<int, int> CancelAndRefund() => _transaction.RefundAll();

  public PurchaseResult TryPurchase(string code)
  {
    if (!_products.TryGetValue(code.Trim(), out var product))
      return PurchaseResult.Fail("Код не найден.");
    if (!product.IsAvailable)
      return PurchaseResult.Fail("Нет в наличии.");
    if (CurrentInsertedRub < product.PriceRub)
      return PurchaseResult.Fail($"Нужно ещё {Format(product.PriceRub - CurrentInsertedRub)}.");

    var tempBank = new Dictionary<int, int>(_coinBank);
    foreach (var kv in _transaction.InsertedCoins)
      tempBank[kv.Key] += kv.Value;

    int changeAmount = CurrentInsertedRub - product.PriceRub;
    var change = new Dictionary<int, int>();
    if (changeAmount > 0 && !TryMakeChange(tempBank, changeAmount, out change))
      return PurchaseResult.Fail("Не могу выдать сдачу этой комбинацией монет.");

    foreach (var kv in _transaction.InsertedCoins)
      _coinBank[kv.Key] += kv.Value;
    foreach (var kv in change)
      _coinBank[kv.Key] -= kv.Value;

    product.TakeOne();
    _revenueRub += product.PriceRub;
    _transaction.Clear();

    return PurchaseResult.Success(product, change);
  }

  public bool CheckAdminPin(string pin) => pin == _adminPin;
  public void RestockProduct(string code, int count)
  {
    if (!_products.TryGetValue(code.Trim(), out var p))
      throw new ArgumentException("Нет товара.");
    p.AddStock(count);
  }
  public void RefillCoins(int denom, int count)
  {
    if (!AcceptedDenominations.Contains(denom) || count <= 0)
      throw new ArgumentException();
    _coinBank[denom] += count;
  }
  public IReadOnlyDictionary<int, int> InspectCoinBank() => _coinBank;
  public int GetRevenueRub() => _revenueRub;
  public int CollectRevenue()
  {
    int c = _revenueRub; _revenueRub = 0; return c;
  }

  private static bool TryMakeChange(Dictionary<int, int> bank, int amount, out Dictionary<int, int> change)
  {
    change = new();
    int left = amount;
    foreach (var d in AcceptedDenominations.OrderByDescending(x => x))
    {
      int use = Math.Min(left / d, bank.GetValueOrDefault(d));
      if (use > 0)
      {
        change[d] = use;
        left -= use * d;
        bank[d] -= use;
      }
      if (left == 0) break;
    }
    if (left != 0) { change.Clear(); return false; }
    return true;
  }

  public static string Format(int rub) => $"{rub} ₽";
  public static string CoinsToString(Dictionary<int, int> coins) =>
      coins.Count == 0 ? "—"
      : string.Join(", ", coins.OrderByDescending(k => k.Key)
      .Select(k => $"{k.Value}×{k.Key}  ₽"));
  public IEnumerable<int> ListAcceptedDenominations()
  => AcceptedDenominations.OrderByDescending(x => x);
}