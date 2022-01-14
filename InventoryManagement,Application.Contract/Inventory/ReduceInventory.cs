﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement_Application.Contract.Inventory
{
    public class ReduceInventory
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}
