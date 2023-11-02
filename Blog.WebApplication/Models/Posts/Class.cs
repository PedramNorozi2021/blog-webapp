namespace Blog.WebApplication.Models.Posts
{
    public class PagingViewModel
    {
        public int CurrentPage { get; set; }
        public int EndPage { get; set; }
    }

    public class PostViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        public string CreationDate { get; set; }
    }
    public class PostPagingViewModel
    {
        public List<PostViewModel> Posts { get; set; }
        public PagingViewModel Paging { get; set; }
    }
}
