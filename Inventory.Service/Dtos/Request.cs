﻿

namespace Inventory.Service.Dtos
{
    public class Request
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int RequestedKernels { get; set; }
    }
}
