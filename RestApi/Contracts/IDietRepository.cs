namespace Contracts
{
    public interface IDietRepository
    {
        void CreateDiet(Diet diet);
        Task<IEnumerable<Diet>> GetAllDietAsync(bool trackChanges);
        Task<Diet> GetDietAsync(Guid dietId, bool trackChanges);
        Task<IEnumerable<Diet>> GetDietsByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteDiet(Diet diet);
    }
}