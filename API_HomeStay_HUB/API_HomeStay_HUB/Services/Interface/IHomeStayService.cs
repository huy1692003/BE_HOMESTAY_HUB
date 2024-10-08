using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IHomeStayService
    {
        Task<IEnumerable<HomeStay?>> getHomeStay();
        Task<IEnumerable<HomeStay?>> searchHomeStay();
        Task<HomeStay?> getHomeStayByID(int ID);
        Task<bool> addHomeStay(HomeStay homeStay);
        Task<bool> updateHomeStay(HomeStay homeStay);
        Task<bool> deleteHomeStay(int ID);
        Task<bool> lockHomeStay(int ID);
    }
}
