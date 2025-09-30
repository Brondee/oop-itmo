namespace VendingMachine;

public class Product
{
  public string Code { get; }
  public string Name { get; }
  public int PriceRub { get; }
  public int Quantity { get; private set; }

  public Product(string code, string name, int priceRub, int quantity)
  {
    if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Код товара пуст.");
    if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Название товара пусто.");
    if (priceRub <= 0) throw new ArgumentException("Цена должна быть > 0.");
    if (quantity < 0) throw new ArgumentException("Количество не может быть отрицательным.");

    Code = code.Trim().ToUpperInvariant();
    Name = name.Trim();
    PriceRub = priceRub;
    Quantity = quantity;
  }

  public bool IsAvailable => Quantity > 0;

  public void AddStock(int count)
  {
    if (count <= 0) throw new ArgumentException("Пополнение должно быть > 0.");
    Quantity += count;
  }

  public void TakeOne()
  {
    if (Quantity <= 0) throw new InvalidOperationException("Товара нет на складе.");
    Quantity--;
  }
}