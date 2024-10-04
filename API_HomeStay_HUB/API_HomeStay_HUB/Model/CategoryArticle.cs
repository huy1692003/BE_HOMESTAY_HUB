using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("CategoryArticles")]
public class CategoryArticle
{
    [Key]
    [Column("cateID")]
    public int? CateID { get; set; }

    [Column("cateName")]
    public string? CateName { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
