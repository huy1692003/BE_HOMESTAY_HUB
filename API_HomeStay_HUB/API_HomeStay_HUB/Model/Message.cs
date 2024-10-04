using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [Column("msgID")]
        public int? MsgID { get; set; }

        [Column("conversationID")]
        public int? ConversationID { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("senderID")]
        public int? SenderID { get; set; }

        [Column("isView")]
        public int? IsView { get; set; }

        [Column("timestamp")]
        public DateTime? Timestamp { get; set; }
    }

}
