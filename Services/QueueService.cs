namespace CoffeeQueue.Services;

public class QueueItem
{
    public string Number { get; set; } = "";
    public string CoffeeType { get; set; } = "";
    public string CoffeeEmoji { get; set; } = "";
    public string Status { get; set; } = "available"; // available, reserved, preparing, ready
    public DateTime? ReservedAt { get; set; }
}

public class QueueService
{
    // ponytail: in-memory list, switch to DB when persistence needed
    private readonly List<QueueItem> _items;
    private readonly object _lock = new();

    public QueueService()
    {
        var types = new[]
        {
            ("Espresso", "☕"),
            ("Americano", "🥤"),
            ("Cappuccino", "☕"),
            ("Latte", "🥛"),
            ("Mocha", "🍫"),
            ("Flat White", "🤎"),
            ("Cold Brew", "🧊"),
            ("Macchiato", "✨"),
        };

        _items = new List<QueueItem>();
        // A01-A20 = 20 items
        for (int i = 1; i <= 20; i++)
        {
            var t = types[(i + 'A') % types.Length];
            _items.Add(new QueueItem
            {
                Number = $"A{i:D2}",
                CoffeeType = t.Item1,
                CoffeeEmoji = t.Item2,
                Status = "available"
            });
        }
    }

    public IReadOnlyList<QueueItem> GetAll() => _items;

    public bool Reserve(string number)
    {
        lock (_lock)
        {
            var item = _items.FirstOrDefault(x => x.Number.Equals(number, StringComparison.OrdinalIgnoreCase));
            if (item == null || item.Status != "available") return false;
            item.Status = "reserved";
            item.ReservedAt = DateTime.Now;
            return true;
        }
    }

    public bool UpdateStatus(string number, string status)
    {
        lock (_lock)
        {
            var item = _items.FirstOrDefault(x => x.Number.Equals(number, StringComparison.OrdinalIgnoreCase));
            if (item == null) return false;
            item.Status = status;
            return true;
        }
    }

    public QueueItem? GetByNumber(string number) =>
        _items.FirstOrDefault(x => x.Number.Equals(number, StringComparison.OrdinalIgnoreCase));
}
