using Task1_LINQ;

List<Order> orders = new List<Order>
        {
            new Order { Customer = "Alice", Amount = 150.00m, Date = new DateTime(2023, 5, 10), Category = "Category1" },
            new Order { Customer = "Bob", Amount = 200.00m, Date = new DateTime(2024, 3, 15), Category = "Category2" },
            new Order { Customer = "Charlie", Amount = 300.00m, Date = new DateTime(2024, 10, 22), Category = "Category2" },
            new Order { Customer = "David", Amount = 100.00m, Date = new DateTime(2025, 1, 5), Category = "Category3" },
            new Order { Customer = "Eve", Amount = 250.00m, Date = new DateTime(2025, 11, 30), Category = "Category1" },
            new Order { Customer = "Frank", Amount = 350.00m, Date = new DateTime(2023, 7, 18), Category = "Category1" },
            new Order { Customer = "Grace", Amount = 400.00m, Date = new DateTime(2024, 2, 8), Category = "Category3" },
            new Order { Customer = "Hannah", Amount = 175.00m, Date = new DateTime(2025, 4, 14), Category = "Category2" },
            new Order { Customer = "Ivy", Amount = 225.00m, Date = new DateTime(2023, 9, 30), Category = "Category3" },
            new Order { Customer = "Jack", Amount = 300.00m, Date = new DateTime(2025, 6, 20), Category = "Category1" },
            new Order { Customer = "Kevin", Amount = 275.00m, Date = new DateTime(2024, 12, 1), Category = "Category2" }
        };

List<Order> lastYearOrders = orders.Where(d => DateTime.Compare(DateTime.Now.AddYears(-1), d.Date) < 0).ToList();

var groupedOrders = lastYearOrders.GroupBy(o => o.Category)
                          .Select(g => new
                          {
                              Category = g.Key,
                              TotalAmount = g.Sum(o => o.Amount),
                              TotalOrders = g.Count(),
                              AverageWage = g.Average(o => o.Amount),
                              LastOrder = g.Max(o => o.Date)
                          }).OrderByDescending(g => g.TotalAmount);

foreach (var orderGroup in groupedOrders)
{
    Console.WriteLine($"Category: {orderGroup.Category}, totalAmount: {orderGroup.TotalAmount}, totalOrders:{orderGroup.TotalOrders} lastDate: {orderGroup.LastOrder.ToShortDateString()}, AvgWage: {orderGroup.AverageWage}");
}
