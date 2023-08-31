using PackPlanner.Models.Entities;

namespace PackPlanner.Repository.Interfaces
{
    public interface IItemRepository
    {
        public IQueryable<Item> ListItems();
        public Task<Item?> GetItemByIdAsync(int id);
        public Task<int> AddItemAsync(Item item);
        public Task UpdateItemAsync(int id, Item item);
        public Task DeleteItemAsync(int id);
    }
}
