using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class PartnershipRegService : IPartnershipRegService
    {
        private readonly IPartnershipRegRepository _partnershipRegRepository;

        public PartnershipRegService(IPartnershipRegRepository partnershipRegRepository)
        {
            _partnershipRegRepository = partnershipRegRepository;
        }
        public async Task<IEnumerable<PartnershipReg?>> getbyStatus(int status)
        {
            return await _partnershipRegRepository.getbyStatus(status);
        }
        public async Task<PartnershipReg?> getDetail_PartnerShip(int id)
        {
            return await _partnershipRegRepository.getDetail_PartnerShip(id);
        }
        public async Task<bool> registerParterShip(PartnershipReg partnershipReg)
        {
            return await _partnershipRegRepository.registerParterShip(partnershipReg);
        }
        public async Task<bool> confirm_PartnerShip(int idPart)
        {
            return await _partnershipRegRepository.updateStatus_PartnerShip(1, idPart);
        }
        public async Task<bool> cancel_PartnerShip(int idPart, string note = "")
        {
            return await _partnershipRegRepository.updateStatus_PartnerShip(2, idPart, note);
        }
    }
}
