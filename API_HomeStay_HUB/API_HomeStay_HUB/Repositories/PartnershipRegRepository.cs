using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class PartnershipRegRepository : IPartnershipRegRepository
    {
        private readonly DBContext _dbContext;
        public PartnershipRegRepository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<PartnershipReg?>> getbyStatus(int status)
        {
            return await _dbContext.PartnershipRegs.Where(s => s.Status == status).ToListAsync();
        }
        public async Task<bool> registerParterShip(PartnershipReg partnershipReg)
        {
            await _dbContext.PartnershipRegs.AddAsync(partnershipReg);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> updateStatus_PartnerShip(int status, int idPart, string noteReject = "")
        {
            var PartnerShip = await _dbContext.PartnershipRegs.FindAsync(idPart);
            if (PartnerShip == null)
            {
                return false;
            }
            else
            {
                //Duyệt đơn đăng ký 
                if (status == 1)
                {
                    PartnerShip.Status = 1;
                    var guid = Guid.NewGuid().ToString();

                    //Tạo OwnerStay khi đã duyệt đơn đăng kí

                    var idUser = (await _dbContext.Customers.FirstOrDefaultAsync(s => s.CusID == PartnerShip.CustomerID))!.UserID;
                    await _dbContext.OwnerStays.AddAsync(new OwnerStay { OwnerID = Guid.NewGuid().ToString(), UserID = idUser });
                }
                //Hủy đơn đăng kí 
                else
                {
                    PartnerShip.Status = 2;
                    PartnerShip.RejectionReason = noteReject;
                }
                return await _dbContext.SaveChangesAsync() > 0;
            }

        }
        public async Task<PartnershipReg?> getDetail_PartnerShip(int id)
        {
            return await _dbContext.PartnershipRegs.FindAsync(id);
        }

    }
}
