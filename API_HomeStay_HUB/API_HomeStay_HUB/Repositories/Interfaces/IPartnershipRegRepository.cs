using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Intefaces
{
    public interface IPartnershipRegRepository
    {
        Task<IEnumerable<PartnershipReg?>> getbyStatus(int status);
        Task<bool> registerParterShip(PartnershipReg partnershipReg);
        Task<bool> updateStatus_PartnerShip(int status, int idPart, string note = "");
        Task<PartnershipReg?> getDetail_PartnerShip(int id);
    }
}
