using PackPlanner.Models.Dtos;

namespace PackPlanner.Services.Interfaces
{
    public interface IPackService
    {
        public Task<IEnumerable<Pack>> ListPacksAsync(ListPackRequest listPackRequest);
        public Task<Pack> GetPackByIdAsync(int id);
        public Task<int> AddPackAsync(Pack pack);
        public Task UpdatePackAsync(int id, Pack pack);
        public Task DeletePackAsync(int id);
    }
}
