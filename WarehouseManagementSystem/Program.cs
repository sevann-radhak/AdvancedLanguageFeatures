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

OrderProcessor processor = new()
{
    OnOrderInitialized = order => order.IsReadyForShipment
};

processor.Process(order, SendConfirmationEmail);
List<Guid> processedOrders = new();

OrderProcessor.ProcessCompleted onCompleted = order =>
{
    processedOrders.Add(order.OrderNumber);
    Console.WriteLine($"Processed {order.OrderNumber}");
};

//onCompleted += order => { Console.WriteLine("Refill stock..."); };

processor.Process(order, onCompleted);

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");
    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");
}