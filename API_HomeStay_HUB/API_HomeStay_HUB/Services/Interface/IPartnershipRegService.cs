using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IPartnershipRegService
    {
        Task<IEnumerable<PartnershipReg?>> getbyStatus(int status);

        Task<bool> registerParterShip(PartnershipReg partnershipReg);
        Task<bool> confirm_PartnerShip(int idPart);
        Task<bool> cancel_PartnerShip(int idPart, string note = "");
        Task<PartnershipReg?> getDetail_PartnerShip(int id);


    }
}
