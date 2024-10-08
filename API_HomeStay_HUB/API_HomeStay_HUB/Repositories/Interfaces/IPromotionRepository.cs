using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Intefaces
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAll();
        Task<Promotion?> GetById(int ID);
        Task<bool> Add(Promotion prm);
        Task<bool> Update(Promotion prm);
        Task<bool> Delete(int ID);
    }
}
