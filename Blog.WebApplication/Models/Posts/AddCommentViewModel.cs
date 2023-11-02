using System.ComponentModel.DataAnnotations;

namespace Blog.WebApplication.Models.Posts;
public class AddCommentViewModel
{
    [Required]
    public long PostId { get; set; }
    [Required(ErrorMessage ="متن نظر خود را وارد کنید")]
    public string Text { get; set; }
    [Required]
    public string UserName { get; set; }
}
