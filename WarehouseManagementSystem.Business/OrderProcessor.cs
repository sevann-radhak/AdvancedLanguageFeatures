﻿using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        public delegate bool OrderInitialized(Order order);
        public delegate void ProcessCompleted(Order order);

        public OrderInitialized OnOrderInitialized { get; set; }

        private void Initialize(Order order)
        {
            ArgumentNullException.ThrowIfNull(order, nameof(order));

            if (!(bool)OnOrderInitialized?.Invoke(order))
            {
                throw new Exception($"Couldn't initialize {order.OrderNumber}");
            }
        }

        public void Process(Order order, ProcessCompleted onCompleted = default)
        {
            Initialize(order);
            onCompleted?.Invoke(order);
        }
    }
}