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
        //Author
        CreateMap<AuthorCreateDTO, Author>().ReverseMap();
        CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
        CreateMap<AuthorGetDTO, Author>().ReverseMap();

        //Book Mapping
        CreateMap<Book, Book>().ReverseMap();
        CreateMap<BookUpdateDTO, Book>().ReverseMap();
        CreateMap<BookGetDTO, Book>().ReverseMap();

        //Commentary
        CreateMap<CommentaryCreateDTO, Commentary>().ReverseMap();
        CreateMap<CommentaryUpdateDTO, Commentary>().ReverseMap();
        CreateMap<CommentaryGetDTO, Commentary>().ReverseMap();

        //Role
        CreateMap<RoleCreateDTO, Role>().ReverseMap();
        CreateMap<RoleUpdateDTO, Role>().ReverseMap();
        CreateMap<RoleGetDTO, Role>().ReverseMap();

        //Category
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        CreateMap<CategoryGetDTO, Category>().ReverseMap();

        //user
        CreateMap<UserCreateDTO, User>().ReverseMap();
        CreateMap<UserUpdateDTO, User>().ReverseMap();
        CreateMap<UserGetDTO, User>().ReverseMap();

        //Permission
        CreateMap<PermissionGetDTO, Permission>().ReverseMap();


    }
}
