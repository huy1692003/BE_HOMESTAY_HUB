namespace API_HomeStay_HUB.Services.Interface
{
    public interface IFavoritesService
    {
        Task<bool> addFavorites(int idHomeStay, string idCus);
        Task<bool> deleteFavorites(int id);
        Task<IEnumerable<dynamic>> getHomeStay_Favorites(string idCus);
    }
}
