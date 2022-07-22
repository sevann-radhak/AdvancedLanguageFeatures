﻿using WarehouseManagementSystem.Business;
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
    OnOrderInitialized  = SendMessageToWarehouse
};

processor.Process(order, SendConfirmationEmail);

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");
    return false;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");
}