using Storyboard.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Storyboard.WebApplication.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdreess"];
        // GET: Article
        public ActionResult Index()
        {
            IEnumerable<ArticleViewModel> articles = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("Article/GetAllBlogPosts");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ArticleViewModel>>();
                    readTask.Wait();

                    articles = readTask.Result;
                }
                else { 

                    articles = Enumerable.Empty<ArticleViewModel>();
                }
            }
            return View(articles);
        }


        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleViewModel collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ArticleViewModel>("Article/CreatePost", collection);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(collection);
        }
        // GET: Article/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ArticleViewModel article = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("Article/GetPost?articleId=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ArticleViewModel>();
                    readTask.Wait();

                    article = readTask.Result;
                }
            }
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(ArticleViewModel article)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ArticleViewModel>("Article/UpdatePost", article);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(article);
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Article/DeletePost?articleId=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewArticle(int id)
        {
            ArticleViewModel article = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("Article/GetPost?articleId=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ArticleViewModel>();
                    readTask.Wait();

                    article = readTask.Result;
                }
            }
            return View(article);
        }
        public ActionResult AllTags()
        {
            IEnumerable<string> articles = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("Article/GetAllTags");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<string>>();
                    readTask.Wait();

                    articles = readTask.Result;
                }
                else
                {
                    articles = Enumerable.Empty<string>();
                }
            }
            return View(articles);
        }
        public ActionResult GetArticlesByTags(string tagName)
        {
            IEnumerable<ArticleViewModel> articles = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("Article/GetPostsByTag?tagName=" + tagName);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ArticleViewModel>>();
                    readTask.Wait();
                    articles = readTask.Result;
                }
                else
                {
                    articles = Enumerable.Empty<ArticleViewModel>();
                }
            }
            return View(articles);
        }
    }
}