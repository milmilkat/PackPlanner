using PackPlanner.Repository.Interfaces;
using PackPlanner.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PackPlanner.Models.Dtos;
using AutoMapper.QueryableExtensions;

namespace PackPlanner.Services.Implementations
{
    public class PackService : IPackService
    {
        private readonly IMapper _mapper;
        private readonly IPackRepository _packRepository;

        public PackService(IPackRepository packRepository, IMapper mapper)
        {
            _packRepository = packRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pack>> ListPacksAsync(ListPackRequest listPackRequest)
        {
            var packs = await _packRepository.ListPacksAsync(listPackRequest);
            return _mapper.Map<IEnumerable<Pack>>(packs);
        }

        public async Task<Pack> GetPackByIdAsync(int id)
        {
            var pack = await _packRepository.GetPackByIdAsync(id);

            if (pack == null)
                throw new ArgumentNullException(nameof(pack));

            return _mapper.Map<Pack>(pack);
        }

        public async Task<int> AddPackAsync(Pack pack)
        {
            var entity = _mapper.Map<Models.Entities.Pack>(pack);
            return await _packRepository.AddPackAsync(entity);
        }        

        public async Task UpdatePackAsync(int id, Pack pack)
        {
            var entity = _mapper.Map<Models.Entities.Pack>(pack);
            await _packRepository.UpdatePackAsync(id, entity);
        }

        public async Task DeletePackAsync(int id)
        {
            await _packRepository.DeletePackAsync(id);
        }
    }
}
