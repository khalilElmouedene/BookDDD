using AutoMapper;
using BookDDD.Core.Entities;
using BookDDD.Application.Features.Posts.Queries.GetAllPost;
using BookDDD.Application.Features.Posts.Commands.CreatePost;
using BookDDD.Application.Features.Membre.Queries.GetMembreList;
using BookDDD.Application.Features.Membre.Commands.UpdateMembre;
using BookDDD.Application.Features.Membre.Queries.GetMembre;
using BookDDD.Application.Features.Commentaire.Queries.GetCommentList;
using BookDDD.Application.Wrapper;

namespace BookDDD.Application.MapperProfile
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Membre, GetMembreLisViewModel>().ReverseMap();
            CreateMap<Membre, UpdateMembreCommand>().ReverseMap();
            CreateMap<Membre, GetMembreViewModel>().ReverseMap();



            CreateMap<PaginatedResult<GetAllPostDto>, PaginatedResult<Post>>().ReverseMap();
            CreateMap<GetAllPostDto, Post>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();

            CreateMap<PaginatedResult<GetCommentViewModel>, PaginatedResult<Comments>>().ReverseMap();
            CreateMap<Comments, GetCommentViewModel>().ReverseMap();
        }
    }
}