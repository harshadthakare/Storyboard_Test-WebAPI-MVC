using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.DTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Tags { get; set; }
        public string ArticleDesc { get; set; }
        public DateTime CreatedOn{ get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
