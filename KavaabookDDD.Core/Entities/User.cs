using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities
{
    public class User : BaseEntity<int>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPicture { get; set; }
    }
}