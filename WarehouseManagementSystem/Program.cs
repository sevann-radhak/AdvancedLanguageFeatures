using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

Order order = new()
{
    LineItems = new[]
    {
        new Item{ Name = "PS1", Price = 50},
        new Item{ Name = "PS2", Price = 60},
        new Item{ Name = "PS4", Price = 70},
        new Item{ Name = "PS5", Price = 80}
    }
};

Func<Order, bool>? isReadyForShipment = order =>
{
    return order.IsReadyForShipment;
};

OrderProcessor processor = new()
{
    OnOrderInitialized = isReadyForShipment
};

processor.Process(order, SendConfirmationEmail);
List<Guid> processedOrders = new();

Action<Order> onCompleted = _ =>
{
    processedOrders.Add(order.OrderNumber);
    Console.WriteLine($"Processed {order.OrderNumber}");
};

//onCompleted += order => { Console.WriteLine("Refill stock..."); };

processor.Process(order, onCompleted);

//Func<Order, bool> func = SendMessageToWarehouse;

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");
    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");
}