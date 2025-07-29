using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Web.Models.Posts
{
    public class PostCreateViewModel
    {
        public string Content { get; set; }
        public int MembreId { get; set; }
        public string UrlsImg { get; set; }
    }
}
