using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HomeStay_HUB.Model
{
    [Table("PartnershipReg")] // Tên bảng trong cơ sở dữ liệu
    public class PartnershipReg
    {
        [Key]
        [Column("id")] // Tên cột trong bảng
        public int Id { get; set; } // Khóa chính, tự động tăng

        [Column("customerID")] // Tên cột trong bảng
        public string? CustomerID { get; set; } // Khóa ngoại liên kết đến bảng Customer

        [Column("companyName")] // Tên cột trong bảng
        public string? CompanyName { get; set; } // Tên công ty

        [Column("fullName")] // Tên cột trong bảng
        public string? FullName { get; set; } // Họ và tên người đại diện

        [Column("address")] // Tên cột trong bảng
        public string? Address { get; set; } // Địa chỉ công ty

        [Column("phoneNumber")] // Tên cột trong bảng
        public string? PhoneNumber { get; set; } // Số điện thoại liên hệ

        [Column("email")] // Tên cột trong bảng
        public string? Email { get; set; } // Địa chỉ email

        [Column("totalHomeStay")] // Tên cột trong bảng
        public int TotalHomeStay { get; set; } // Tổng số homestay

        [Column("imgPreview")] // Tên cột trong bảng
        public string? ImgPreview { get; set; } // Đường dẫn hình ảnh xem trước

        [Column("partnershipAgreement")] // Tên cột trong bảng
        public string? PartnershipAgreement { get; set; } // Thỏa thuận hợp tác

        [Column("businessLicense")] // Tên cột trong bảng
        public string? BusinessLicense { get; set; } // Số giấy phép kinh doanh (nếu có)

        [Column("bankAccount")] // Tên cột trong bảng
        public string? BankAccount { get; set; } // Thông tin tài khoản ngân hàng để thanh toán

        [Column("status")] // Tên cột trong bảng
        public int Status { get; set; } // Trạng thái đơn đăng ký

        [Column("rejectionReason")] // Tên cột trong bảng
        public string? RejectionReason { get; set; } // Trạng thái đơn đăng ký

        [Column("createdAt")] // Tên cột trong bảng
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Thời gian tạo bản ghi

        [Column("updatedAt")] // Tên cột trong bảng
        public DateTime? UpdatedAt { get; set; } // Thời gian cập nhật bản ghi

        // Bạn có thể thêm mối quan hệ với bảng Customer nếu cần
        // public virtual Customer? Customer { get; set; } 
    }
}
