using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly DBContext _dBContext;
        public FavoritesRepository(DBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public async Task<bool> addFavorites(int idHomeStay, string idCus)
        {
            if (_dBContext.HomeStays.Any(s => s.HomestayID == idHomeStay) && _dBContext.Customers.Any(s => s.CusID == idCus))
            {

                if (await _dBContext.Favorites.FirstOrDefaultAsync(f => f.HomestayID == idHomeStay && f.CusID == idCus) == null)
                {
                    await _dBContext.Favorites.AddAsync(new Favorites { CusID = idCus, HomestayID = idHomeStay });
                    return await _dBContext.SaveChangesAsync() > 0;

                }
                return false;
            }
            return false;
        }
        public async Task<bool> deleteFavorites(int id)
        {
            var Fav = await _dBContext.Favorites.SingleOrDefaultAsync(s => s.FavID == id);

            if (Fav != null)
            {
                _dBContext.Remove(id);
                return await _dBContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<IEnumerable<dynamic>> getHomeStay_Favorites(string idCus)
        {
            var result = await (from f in _dBContext.Favorites
                                join h in _dBContext.HomeStays
                                on f.HomestayID equals h.HomestayID
                                where f.CusID == idCus
                                select new
                                {
                                    cusID = f.CusID,
                                    favoriteID=f.FavID,
                                    homestay = h
                                }).ToListAsync();
            return result;
        }
    }
}
