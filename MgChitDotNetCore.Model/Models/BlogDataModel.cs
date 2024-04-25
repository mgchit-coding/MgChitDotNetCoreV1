using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MgChitDotNetCore.Model.Models;
[Table("Tbl_Blog")]
public class BlogDataModel
{
    [Key]
    public int BlogId { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogTitle { get; set; }
    public string BlogContent { get; set; }
}
