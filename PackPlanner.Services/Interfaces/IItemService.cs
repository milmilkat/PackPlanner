using PackPlanner.Models.Dtos;

namespace PackPlanner.Services.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<Item>> ListItemsAsync();
        public Task<Item> GetItemByIdAsync(int id);
        public Task<int> AddItemAsync(Item item);
        public Task UpdateItemAsync(int id, Item item);
        public Task DeleteItemAsync(int id);
    }
}
