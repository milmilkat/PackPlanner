using PackPlanner.Models.Entities;

namespace PackPlanner.Repository.Interfaces
{
    public interface IPackRepository
    {
        public Task<IEnumerable<Pack>> ListPacksAsync(Models.Dtos.ListPackRequest listPackRequest);
        public Task<Pack?> GetPackByIdAsync(int id);
        public Task<int> AddPackAsync(Pack pack);
        public Task UpdatePackAsync(int id, Pack pack);
        public Task DeletePackAsync(int id);
    }
}
