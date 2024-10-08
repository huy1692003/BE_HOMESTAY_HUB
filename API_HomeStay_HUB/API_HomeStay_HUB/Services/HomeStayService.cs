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

        public async Task<IEnumerable<HomeStay?>> getHomeStay()
        {
            return await _homeStayRepository.getHomeStay();
        }
        public async Task<IEnumerable<HomeStay?>> searchHomeStay()
        {
            return await _homeStayRepository.searchHomeStay();
        }
        public async Task<HomeStay?> getHomeStayByID(int ID)
        {
            return await _homeStayRepository.getHomeStayByID(ID);
        }
        public async Task<bool> addHomeStay(HomeStay homeStay)
        {
            return await _homeStayRepository.addHomeStay(homeStay);
        }
        public async Task<bool> updateHomeStay(HomeStay homeStay)
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
