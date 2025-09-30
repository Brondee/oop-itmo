namespace VendingMachine;

public class PurchaseResult
{
    public bool Ok { get; }
    public Product? Product { get; }
    public Dictionary<int, int> Change { get; } = new();
    public string? Error { get; }

    private PurchaseResult(bool ok, Product? product, Dictionary<int, int>? change, string? error)
    { Ok = ok; Product = product; if (change != null) Change = change; Error = error; }

    public static PurchaseResult Success(Product p, Dictionary<int, int> change) => new(true, p, change, null);
    public static PurchaseResult Fail(string error) => new(false, null, null, error);
}