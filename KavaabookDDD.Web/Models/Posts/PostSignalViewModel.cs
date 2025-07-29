using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Web.Models.Posts
{
    public class PostSignalViewModel
    {
        public string Reason { get; set; }
        public int PostId { get; set; }
        public int MembreId { get; set; }
    }
}
