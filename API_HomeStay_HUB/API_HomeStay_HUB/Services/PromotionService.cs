using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _proRes;
        public PromotionService(IPromotionRepository _proRes)
        {
            this._proRes = _proRes;
        }
        public async Task<IEnumerable<Promotion>> GetAll()
        {
            return await _proRes.GetAll();
        }
        public async Task<Promotion?> GetById(int ID)
        {
            return await _proRes.GetById(ID);
        }
        public async Task<bool> Add(Promotion prm)
        {
           return await _proRes.Add(prm);
        }
        public async Task<bool> Update(Promotion prm)
        {
            return await _proRes.Update(prm);

        }
        public async Task<bool> Delete(int ID)
        {
            return await _proRes.Delete(ID);

        }
    }
}
