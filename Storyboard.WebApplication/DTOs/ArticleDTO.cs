using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Storyboard.WebApplication.DTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Article Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Article Short Description")]
        public string ShortDesc { get; set; }
        [Required]
        [Display(Name = "Article Tags")]
        public string Tags { get; set; }
        [Required]
        [AllowHtml]
        [Display(Name = "Article Description")]
        public string ArticleDesc { get; set; }

    }
}
