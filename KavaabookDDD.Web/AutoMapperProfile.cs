using AutoMapper;
using BookDDD.Core.Entities;
using BookDDD.Core.Entities.ObjectValue;
using BookDDD.Web.Models.MemberDto;
using BookDDD.Web.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostViewModel, Post>().ReverseMap();
            CreateMap<PostSignalViewModel, Post>().ReverseMap();
            CreateMap<PostUpdateViewModel, Post>().ReverseMap();
            CreateMap<PostCreateViewModel, Post>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Membre, MemberDto>().ReverseMap();
            CreateMap<CreateMemberDto, Membre>().ReverseMap();
            CreateMap<MemberDto, Membre>().ReverseMap();
        }
    }
}