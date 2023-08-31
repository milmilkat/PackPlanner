using PackPlanner.Repository.Interfaces;
using PackPlanner.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PackPlanner.Models.Dtos;
using AutoMapper.QueryableExtensions;

namespace PackPlanner.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Item>> ListItemsAsync()
        {
            return await _itemRepository.ListItems()
                .ProjectTo<Item>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return _mapper.Map<Item>(item);
        }

        public async Task<int> AddItemAsync(Item item)
        {
            var entity = _mapper.Map<Models.Entities.Item>(item);
            return await _itemRepository.AddItemAsync(entity);
        }        

        public async Task UpdateItemAsync(int id, Item item)
        {
            var entity = _mapper.Map<Models.Entities.Item>(item);
            await _itemRepository.UpdateItemAsync(id, entity);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }
    }
}
