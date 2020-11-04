using Storyboard.Data.DTOs;
using Storyboard.Data.EntityModel;
using Storyboard.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public bool CreatePost(ArticleDTO data)
        {

            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    context.Articles.Add(new Article()
                    {
                        Title = data.Title,
                        ShortDesc = data.ShortDesc,
                        Tags = data.Tags,
                        ArticleDesc = data.ArticleDesc,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now
                    });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePost(int articleId)
        {
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    Article article = context.Articles.Where(x => x.Id == articleId && x.IsDeleted == false).FirstOrDefault();

                    context.Articles.Add(new Article()
                    {
                        IsDeleted = true,
                        ModifiedOn = DateTime.Now
                    });
                    context.Entry(article).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArticleDTO> GetAllBlogPosts()
        {
            List<ArticleDTO> articleDTOList = new List<ArticleDTO>();
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    List<Article> articles = context.Articles.Where(x => x.IsDeleted == false).ToList();
                    if (articles.Count > 0)
                    {
                        foreach (var item in articles)
                        {
                            articleDTOList.Add(new ArticleDTO
                            {
                                Id = item.Id,
                                Title = item.Title,
                                Tags = item.Tags,
                                ShortDesc = item.ShortDesc,
                                ArticleDesc = item.ArticleDesc
                            });
                        }
                    }
                    else
                    {
                        return null;
                    }
                    return articleDTOList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ArticleDTO GetPost(int articleId)
        {
            ArticleDTO articleDTO = new ArticleDTO();
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    Article article = context.Articles.Where(x => x.Id == articleId && x.IsDeleted == false).FirstOrDefault();
                    if (article != null)
                    {
                        articleDTO = new ArticleDTO
                        {
                            Id = article.Id,
                            Title = article.Title,
                            Tags = article.Tags,
                            ShortDesc = article.ShortDesc,
                            ArticleDesc = article.ArticleDesc
                        };
                    }
                    else
                    {
                        return null;
                    }
                    return articleDTO;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ArticleDTO> GetPostsByTag(string tagName)
        {
            List<ArticleDTO> articleDTOList = new List<ArticleDTO>();
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    List<Article> articles = context.Articles.Where(x =>x.Tags == tagName && x.IsDeleted == false).ToList();
                    if (articles.Count > 0)
                    {
                        foreach (var item in articles)
                        {
                            articleDTOList.Add(new ArticleDTO
                            {
                                Id = item.Id,
                                Title = item.Title,
                                Tags = item.Tags,
                                ShortDesc = item.ShortDesc,
                                ArticleDesc = item.ArticleDesc
                            });
                        }

                    }
                    else
                    {
                        return null;
                    }
                    return articleDTOList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdatePost(ArticleDTO data)
        {
            try
            {
                using (StoryboardDBEntities context = new StoryboardDBEntities())
                {
                    Article article = context.Articles.Where(x => x.Id == data.Id && x.IsDeleted == false).FirstOrDefault();

                    context.Articles.Add(new Article()
                    {
                        Title = data.Title,
                        ShortDesc = data.ShortDesc,
                        Tags = data.Tags,
                        ArticleDesc = data.ArticleDesc,
                        ModifiedOn = DateTime.Now
                    });
                    context.Entry(article).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
