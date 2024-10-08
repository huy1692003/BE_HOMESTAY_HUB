using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAll();
        Task<Promotion?> GetById(int ID);
        Task<bool> Add(Promotion prm);
        Task<bool> Update(Promotion prm);
        Task<bool> Delete(int ID);
    }
}
