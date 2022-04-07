
using Inventory.Service.Dtos;

namespace Inventory.Service.Contracts
{
    public interface IInventoryService
    {
        public Task<InventoryResponseDto> GetInventoryData();
        public Task<bool> ValidateRequestedKernals(int inventoryId, int requestedKernels);
    }
}
