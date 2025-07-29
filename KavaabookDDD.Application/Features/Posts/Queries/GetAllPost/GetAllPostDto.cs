using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostDto
    {
        public string Content { get; set; }
        public int Id { get; set; }
        public string UrlsImg { get; set; }
    }
}
