using Inventory.Service.Dtos;
using RestEase;
namespace Inventory.Service.Api
{
    
    public interface IInventoryDataApi
    {
        [Get("0077e191-c3ae-47f6-bbbd-3b3b905e4a60")]
        Task<string> GetInventoryData();
    }
}
