using Inventory.Service.Api;
using Inventory.Service.Contracts;
using Inventory.Service.Dtos;
using Newtonsoft.Json;
using RestEase;
namespace Inventory.Service.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryDataApi _inventoryDataApi;
        private readonly string _baseUrl = "https://mocki.io/v1/";
        public InventoryService()
        {
            _inventoryDataApi = RestClient.For<IInventoryDataApi>(_baseUrl);
        }
        public async Task<InventoryResponseDto> GetInventoryData()
        {
            var result = await _inventoryDataApi.GetInventoryData();
            return JsonConvert.DeserializeObject<InventoryResponseDto>(result);
        }
        public async Task<bool> ValidateRequestedKernals(int inventoryId, int requestedKernels)
        {
            InventoryResponseDto inventoryResponse = await GetInventoryData();
            if(inventoryResponse!=null)
            {
                var availableKernals = inventoryResponse?.inventory?.Where(x => x.Id == inventoryId).First().kernels;
                var inventoryRequested = inventoryResponse?.requests?.Where(x=>x.InventoryId == inventoryId)
                        .GroupBy(x =>  inventoryId)
                        .Select(x => x.Sum(y => Convert.ToInt32(y.RequestedKernels))).Sum();

                int availbleCheck = (availableKernals.Value - requestedKernels) - inventoryRequested.Value;
                if (availbleCheck > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

    }
}
