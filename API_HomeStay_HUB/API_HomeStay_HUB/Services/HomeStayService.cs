using API_HomeStay_HUB.DTOs;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class HomeStayService : IHomeStayService
    {
        private readonly IHomeStayRepository _homeStayRepository;

        public HomeStayService(IHomeStayRepository homeStayRepository)
        {
            _homeStayRepository = homeStayRepository;
        }

        public async Task<IEnumerable<HomeStayResDTO?>> getHomeStay()
        {
            return await _homeStayRepository.getHomeStay();
        }
        public async Task<IEnumerable<HomeStayResDTO?>> searchHomeStay()
        {
            return await _homeStayRepository.searchHomeStay();
        }
        public async Task<HomeStayDetailDTO?> getHomeStayByID(int ID)
        {
            return await _homeStayRepository.getHomeStayByID(ID);
        }
        public async Task<bool> addHomeStay(HomeStayReqDTO homeStay)
        {
            return await _homeStayRepository.addHomeStay(homeStay);
        }
        public async Task<bool> updateHomeStay(HomeStayReqDTO homeStay)
        {
            return await _homeStayRepository.updateHomeStay(homeStay);
        }
        public async Task<bool> deleteHomeStay(int ID)
        {
            return await _homeStayRepository.deleteHomeStay(ID);
        }
        public async Task<bool> lockHomeStay(int ID)
        {
            return await _homeStayRepository.deleteHomeStay(ID);
        }

    }
}
