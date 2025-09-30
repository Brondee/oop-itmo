namespace VendingMachine;

public static class Program
{
  static void Main()
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    var vm = new VendingMachine(adminPin: "1234");
    Seed(vm);

    while (true)
    {
      Console.WriteLine();
      Console.WriteLine("══════════ ВЕНДИНГОВЫЙ АВТОМАТ ══════════");
      Console.WriteLine(" 1) Показать товары");
      Console.WriteLine(" 2) Внести монету");
      Console.WriteLine(" 3) Выбрать товар");
      Console.WriteLine(" 4) Отмена и возврат монет");
      Console.WriteLine(" 5) Администратор");
      Console.WriteLine(" 0) Выход");
      Console.WriteLine("───────────────────────────────────────────");
      Console.WriteLine($"Внесено: {VendingMachine.Format(vm.CurrentInsertedRub)}");
      Console.Write("Выбор: ");

      var choice = Console.ReadLine()?.Trim();

      try
      {
        switch (choice)
        {
          case "1":
            ShowProducts(vm);
            break;
          case "2":
            InsertCoinFlow(vm);
            break;
          case "3":
            PurchaseFlow(vm);
            break;
          case "4":
            RefundFlow(vm);
            break;
          case "5":
            AdminFlow(vm);
            break;
          case "0":
            Console.WriteLine("Пока!");
            return;
          default:
            Console.WriteLine("Неизвестная команда.");
            break;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }
  }

  private static void Seed(VendingMachine vm)
  {
    vm.AddProduct(new Product("A1", "Вода 0.5л", 70, 5));
    vm.AddProduct(new Product("A2", "Сок яблочный", 85, 3));
    vm.AddProduct(new Product("B1", "Шоколад", 65, 6));
    vm.AddProduct(new Product("B2", "Чипсы", 90, 4));
    vm.AddProduct(new Product("C1", "Кофе", 50, 8));

    vm.RefillCoins(500, 10);
    vm.RefillCoins(200, 10);
    vm.RefillCoins(100, 10);
    vm.RefillCoins(50, 10);
    vm.RefillCoins(10, 20);
  }

  private static void ShowProducts(VendingMachine vm)
  {
    Console.WriteLine();
    Console.WriteLine("Список товаров:");
    Console.WriteLine("Код  | Название           | Цена   | Остаток");
    Console.WriteLine("-----+--------------------+--------+--------");
    foreach (var p in vm.ListProducts())
    {
      string price = VendingMachine.Format(p.PriceRub);
      Console.WriteLine($"{p.Code,-4} | {p.Name,-18} | {price,6} | {p.IsAvailable,6}");
    }
  }

  private static void InsertCoinFlow(VendingMachine vm)
  {
    Console.WriteLine();
    Console.WriteLine("Принимаемые номиналы (в рублях):");
    Console.WriteLine(string.Join(", ", vm.ListAcceptedDenominations().Select(d => d.ToString())));
    Console.Write("Введите номинал монеты: ");
    if (!int.TryParse(Console.ReadLine(), out var denom))
    {
      Console.WriteLine("Некорректный ввод.");
      return;
    }

    vm.InsertCoin(denom);
    Console.WriteLine($"Принято: {VendingMachine.Format(denom)}. Всего внесено: {VendingMachine.Format(vm.CurrentInsertedRub)}.");
  }

  private static void PurchaseFlow(VendingMachine vm)
  {
    Console.Write("Введите код товара (напр. A1): ");
    var code = Console.ReadLine() ?? "";

    var result = vm.TryPurchase(code);
    if (!result.Ok)
    {
      Console.WriteLine($"Покупка отклонена: {result.Error}");
      return;
    }

    Console.WriteLine($"Выдан товар: {result.Product!.Name} ({VendingMachine.Format(result.Product.PriceRub)}).");

    if (result.Change.Count > 0)
    {
      Console.WriteLine($"Сдача: {VendingMachine.CoinsToString(result.Change)} (итого {VendingMachine.Format(result.Change.Sum(kv => kv.Key * kv.Value))}).");
    }
    else
    {
      Console.WriteLine("Сдача: не требуется.");
    }
  }

  private static void RefundFlow(VendingMachine vm)
  {
    var refund = vm.CancelAndRefund();
    int total = refund.Sum(kv => kv.Key * kv.Value);
    Console.WriteLine($"Возврат: {VendingMachine.CoinsToString(refund)} (итого {VendingMachine.Format(total)}).");
  }

  private static void AdminFlow(VendingMachine vm)
  {
    Console.Write("Введите PIN администратора: ");
    var pin = Console.ReadLine() ?? "";
    if (!vm.CheckAdminPin(pin))
    {
      Console.WriteLine("Неверный PIN.");
      return;
    }

    while (true)
    {
      Console.WriteLine();
      Console.WriteLine("══════════ АДМИН-МЕНЮ ══════════");
      Console.WriteLine(" 1) Пополнить товар");
      Console.WriteLine(" 2) Пополнить банк монет");
      Console.WriteLine(" 3) Посмотреть банк монет");
      Console.WriteLine(" 4) Посмотреть выручку");
      Console.WriteLine(" 5) Собрать выручку (обнулить счётчик)");
      Console.WriteLine(" 6) Добавить новый товар");
      Console.WriteLine(" 0) Назад");
      Console.Write("Выбор: ");

      var c = Console.ReadLine()?.Trim();
      try
      {
        switch (c)
        {
          case "1":
            Console.Write("Код товара: ");
            var code = Console.ReadLine() ?? "";
            Console.Write("На сколько пополнить (шт): ");
            if (!int.TryParse(Console.ReadLine(), out var addQty) || addQty <= 0)
            {
              Console.WriteLine("Некорректное количество.");
              break;
            }
            vm.RestockProduct(code, addQty);
            Console.WriteLine("Готово.");
            break;

          case "2":
            Console.WriteLine("Доступные номиналы: " +
                string.Join(", ", VendingMachine.AcceptedDenominations.Select(d => d.ToString())));
            Console.Write("Номинал (₽): ");
            if (!int.TryParse(Console.ReadLine(), out var denom))
            {
              Console.WriteLine("Некорректный номинал.");
              break;
            }
            Console.Write("Количество: ");
            if (!int.TryParse(Console.ReadLine(), out var count) || count <= 0)
            {
              Console.WriteLine("Некорректное количество.");
              break;
            }
            vm.RefillCoins(denom, count);
            Console.WriteLine("Готово.");
            break;

          case "3":
            var bank = vm.InspectCoinBank();
            Console.WriteLine("Банк монет (для сдачи):");
            foreach (var kv in bank.OrderByDescending(k => k.Key))
            {
              Console.WriteLine($" - {VendingMachine.Format(kv.Key)}: {kv.Value} шт.");
            }
            int bankTotal = bank.Sum(kv => kv.Key * kv.Value);
            Console.WriteLine($"Итого в банке: {VendingMachine.Format(bankTotal)} (монеты для выдачи сдачи).");
            break;

          case "4":
            Console.WriteLine($"Выручка (сумма проданных товаров): {VendingMachine.Format(vm.GetRevenueRub())}");
            break;

          case "5":
            int collected = vm.CollectRevenue();
            Console.WriteLine($"Собрано: {VendingMachine.Format(collected)}. Счётчик выручки обнулён.");
            break;

          case "6":
            Console.Write("Новый код товара (например, A3): ");
            var newCode = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Название: ");
            var newName = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Цена (₽, целое число): ");
            if (!int.TryParse(Console.ReadLine(), out var newPrice) || newPrice <= 0)
            {
              Console.WriteLine("Некорректная цена.");
              break;
            }
            Console.Write("Начальный остаток (шт): ");
            if (!int.TryParse(Console.ReadLine(), out var newQty) || newQty < 0)
            {
              Console.WriteLine("Некорректное количество.");
              break;
            }

            try
            {
              vm.AddProduct(new Product(newCode, newName, newPrice, newQty));
              Console.WriteLine($"Товар добавлен: {newCode} — {newName} ({VendingMachine.Format(newPrice)}), остаток {newQty} шт.");
            }
            catch (Exception exAdd)
            {
              Console.WriteLine($"Ошибка добавления товара: {exAdd.Message}");
            }
            break;

          case "0":
            return;

          default:
            Console.WriteLine("Неизвестная команда.");
            break;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }
  }
}