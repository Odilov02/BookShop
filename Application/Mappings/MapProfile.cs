using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.DTOs.Categories;
using Application.DTOs.Commentaries;
using Application.DTOs.Permissions;
using Application.DTOs.Roles;
using Application.DTOs.users;
using Application.DTOs.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.IdentityEntities;

namespace Application.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        AuthorMapping();

        BookMapping();

        CommentaryMappping();


        RoleMapping();

        CategoryMapping();

        UserMapping();

        PermissionMapping();

        void AuthorMapping()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
            CreateMap<AuthorGetDTO, Author>().ReverseMap();
        }

        void BookMapping()
        {
            CreateMap<Book, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<BookGetDTO, Book>().ReverseMap();
        }

        void CommentaryMappping()
        {
            CreateMap<CommentaryCreateDTO, Commentary>().ReverseMap();
            CreateMap<CommentaryUpdateDTO, Commentary>().ReverseMap();
            CreateMap<CommentaryGetDTO, Commentary>().ReverseMap();
        }

        void RoleMapping()
        {
            CreateMap<RoleCreateDTO, Role>().ReverseMap();
            CreateMap<RoleUpdateDTO, Role>().ReverseMap();
            CreateMap<RoleGetDTO, Role>().ReverseMap();
        }

        void CategoryMapping()
        {
            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
            CreateMap<CategoryGetDTO, Category>().ReverseMap();
        }

        void UserMapping()
        {
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();
            CreateMap<UserGetDTO, User>().ReverseMap();
        }

        void PermissionMapping()
        {
            CreateMap<PermissionGetDTO, Permission>().ReverseMap();
        }
    }
}
