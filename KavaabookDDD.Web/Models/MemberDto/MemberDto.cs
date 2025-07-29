using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Web.Models.MemberDto
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPicture { get; set; }
    }

    public class CreateMemberDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPicture { get; set; }
    }

    public class EditMemberDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPicture { get; set; }
    }

    public class SignalerMemberDto
    {
        public int MembreSignaledId { get; set; }
        public int MembreWhoSignalId { get; set; }
        public string CommenterSignaler { get; set; }
    }
}