using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace API_HomeStay_HUB.Model
{

    [Table("Articles")]
    public class Article
    {
        [Key]
        [Column("articleID")]
        public int? ArticleID { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("picturePreview")]
        public string? PicturePreview { get; set; }

        [Column("authorID")]
        public string? AuthorID { get; set; }

        [Column("publishDate")]
        public DateTime? PublishDate { get; set; }

        [Column("cateArtID")]
        public int? CateArtID { get; set; }
    }
}
