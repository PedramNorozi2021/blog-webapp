using Blog.WebApplication.Models;
using Blog.WebApplication.Models.Posts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Blog.WebApplication.Controllers
{
    public class PostsController : Controller
    {
        private ServerBaseUrlViewModel _serverBaseUrlViewModel;

        public PostsController(ServerBaseUrlViewModel serverBaseUrlViewModel)
        {
            _serverBaseUrlViewModel = serverBaseUrlViewModel;
        }

        [Route("posts/{slug}")]
        public async Task<IActionResult> PostDetail(string slug)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_serverBaseUrlViewModel.Value);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStringAsync("api/Posts/" + slug);
            var model = JsonConvert.DeserializeObject<PostDetailDto>(response);
            return View(model);
        }
    }
}
