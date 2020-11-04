using Storyboard.WebApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.WebApplication.Interfaces
{
    public interface IArticleRepository
    {
        bool CreatePost(ArticleDTO data);
        bool UpdatePost(ArticleDTO data);
        bool DeletePost(int articleId);
        List<ArticleDTO> GetAllBlogPosts();
        ArticleDTO GetPost(int articleId);
        List<ArticleDTO> GetPostsByTag(string tagName);
        List<string> GetAllTags();
    }
}
