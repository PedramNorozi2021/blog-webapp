namespace Blog.WebApplication.Models.Posts;

public class PostDetailDto : PostViewModel
{
    public List<PostCommentViewModel> Comments { get; set; }
}

public class PostCommentViewModel
{
    public string UserName { get; set; }
    public string Text { get; set; }
    public string CreateDate { get; set; }
}
