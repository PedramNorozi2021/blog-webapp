using Blog.WebApplication.Models;
using Blog.WebApplication.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Blog.WebApplication.Controllers;
public class HomeController : Controller
{
    private ServerBaseUrlViewModel _serverBaseUrlViewModel;

    public HomeController(ServerBaseUrlViewModel serverBaseUrlViewModel)
    {
        _serverBaseUrlViewModel = serverBaseUrlViewModel;
    }

    public async Task<IActionResult> Index(int pageId = 1)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(_serverBaseUrlViewModel.Value);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetStringAsync("api/Posts?pageId=" + pageId);

        var model = JsonConvert.DeserializeObject<PostPagingViewModel>(response);
        return View(model);
    }

}
