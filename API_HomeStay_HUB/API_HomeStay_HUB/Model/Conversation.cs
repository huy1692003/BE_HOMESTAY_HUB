using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_HomeStay_HUB.Model
{
    [Table("Conversations")]
    public class Conversation
    {
        [Key]
        [Column("conversationID")]
        public int? ConversationID { get; set; }

        [Column("customerID")]
        public string? CustomerID { get; set; }

        [Column("receiverID")]
        public string? ReceiverID { get; set; }

        [Column("ownerID")]
        public string? OwnerID { get; set; }

        [Column("typeConversation")]
        public int? TypeConversation { get; set; }

        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("lastMessageAt")]
        public DateTime? LastMessageAt { get; set; }

        [Column("receivedStatus")]
        public int? ReceivedStatus { get; set; }
    }

}
