using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Web.Models.Posts
{
    public class PostUpdateViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UrlsImg { get; set; }
    }
}
