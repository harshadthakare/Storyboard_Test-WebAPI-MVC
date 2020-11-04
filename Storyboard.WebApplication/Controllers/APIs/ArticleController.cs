using Storyboard.WebApplication.DTOs;
using Storyboard.WebApplication.Interfaces;
using Storyboard.WebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Storyboard.WebApplication.Controllers.APIs
{
    [RoutePrefix("Api/Article")]
    public class ArticleController : ApiController
    {
        private IArticleRepository articleRepository;
        public ArticleController()
        {
            articleRepository = new ArticleRepository();
        }
        [HttpPost]
        [Route("CreatePost")]
        public IHttpActionResult CreatePost(ArticleDTO articleData)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                articleRepository.CreatePost(articleData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();

        }
        [HttpPut]
        [Route("UpdatePost")]
        public IHttpActionResult UpdatePost(ArticleDTO articleData)
        {
            try
            {
                bool result;
                result = articleRepository.UpdatePost(articleData);
                if (result == true)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete]
        [Route("DeletePost")]
        public HttpResponseMessage DeletePost(int articleId)
        {
            try
            {
                bool result;
                result = articleRepository.DeletePost(articleId);
                if (result == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        public HttpResponseMessage GetPostsByTag(string tagName)
        {
            try
            {
                List<ArticleDTO> result = new List<ArticleDTO>();
                result = articleRepository.GetPostsByTag(tagName);
                if (result.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetPost")]
        public HttpResponseMessage GetPost(int articleId)
        {
            try
            {
                ArticleDTO result = new ArticleDTO();
                result = articleRepository.GetPost(articleId);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        [Route("GetAllBlogPosts")]
        public HttpResponseMessage GetAllBlogPosts()
        {
            List<ArticleDTO> result = new List<ArticleDTO>();
            try
            {
                result = articleRepository.GetAllBlogPosts();
                if (result.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetAllTags")]
        public HttpResponseMessage GetAllTags()
        {
            List<string> result = new List<string>();
            try
            {
                result = articleRepository.GetAllTags();
                if (result.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
