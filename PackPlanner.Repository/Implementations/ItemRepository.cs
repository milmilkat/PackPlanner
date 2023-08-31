using PackPlanner.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using PackPlanner.Models.Entities;
using AutoMapper;
using PackPlanner.Repository.Context;

namespace PackPlanner.Repository.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ItemRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IQueryable<Item> ListItems()
        {
            return _dataContext.Items.AsQueryable();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _dataContext.Items.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<int> AddItemAsync(Item item)
        {
            //Pack? pack = null;
            //if(item.Pack != null)
            //{
            //    pack = await _dataContext.Packs.FirstOrDefaultAsync(pack => pack.Id == item.Pack.Id);
            //}

            //if(pack == null)
            //{
            //    _dataContext.Add(pack);
            //}

            _dataContext.Add(item);
            await _dataContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task UpdateItemAsync(int id, Item item)
        {
            var entity = await _dataContext.Items.FirstOrDefaultAsync(itemEntity => itemEntity.Id == id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity = _mapper.Map<Item>(entity);

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var entity = await _dataContext.Items.FirstOrDefaultAsync(itemEntity => itemEntity.Id == id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
