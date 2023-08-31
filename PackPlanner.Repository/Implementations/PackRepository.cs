using PackPlanner.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using PackPlanner.Models.Entities;
using AutoMapper;
using PackPlanner.Repository.Context;
using System.Collections.Generic;
using PackPlanner.Utils.Extensions;

namespace PackPlanner.Repository.Implementations
{
    public class PackRepository : IPackRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PackRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pack>> ListPacksAsync(Models.Dtos.ListPackRequest listPackRequest)
        {
            var items = await _dataContext.Items.ToListAsync();
            var packs = items.OrderItems(listPackRequest.OrderType)
                .PackItems(listPackRequest);

            return packs;
        }

        public async Task<Pack?> GetPackByIdAsync(int id)
        {
            return await _dataContext.Packs.FirstOrDefaultAsync(pack => pack.Id == id);
        }

        public async Task<int> AddPackAsync(Pack pack)
        {
            _dataContext.Add(pack);
            await _dataContext.SaveChangesAsync();
            return pack.Id;
        }

        public async Task UpdatePackAsync(int id, Pack pack)
        {
            var entity = await _dataContext.Packs.FirstOrDefaultAsync(packEntity => packEntity.Id == id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity = _mapper.Map<Pack>(entity);

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePackAsync(int id)
        {
            var entity = await _dataContext.Packs.FirstOrDefaultAsync(packEntity => packEntity.Id == id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
