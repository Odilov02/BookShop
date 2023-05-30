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
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

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
    }
    void AuthorMapping()
    {
        CreateMap<AuthorCreateDTO, Author>().ReverseMap();
        CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
        CreateMap<Author, AuthorGetDTO>().ForMember(dest => dest.BooksId, opt => opt.MapFrom(src=>src!.Books!.Select(x=>x.Id)));
        CreateMap<AuthorGetDTO, Author>().ForMember(dest =>dest.Books!.Select(x => x.Id), opt => opt.MapFrom(src=>src.BooksId));
    }

    void BookMapping()
    {
        CreateMap<BookCreateDTO, Book>().ReverseMap();
        CreateMap<BookUpdateDTO, Book>().ReverseMap();
        CreateMap<BookGetDTO, Book>().ForMember(dest => dest.Commentaries!.Select(c => c.Id), opt => opt.MapFrom(c => c.CommentariesId));
        CreateMap<Book, BookGetDTO>().ForMember(dest => dest.CommentariesId!, opt => opt.MapFrom(c => c.Commentaries!.Select(c => c.Id)));
    }

    void CommentaryMappping()
    {
        CreateMap<CommentaryCreateDTO, Commentary>().ReverseMap();
        CreateMap<CommentaryUpdateDTO, Commentary>().ReverseMap();
        CreateMap<CommentaryGetDTO, Commentary>().ReverseMap();
    }

    void RoleMapping()
    {
        CreateMap<RoleCreateDTO, Role>().ForMember(dest => dest.permissions!.Select(c => c.Id), opt => opt.MapFrom(c => c.permissionsId));
        CreateMap<Role, RoleCreateDTO>().ForMember(dest => dest.permissionsId, opt => opt.MapFrom(c => c.permissions!.Select(x=>x.Id)));

        CreateMap<RoleUpdateDTO, Role>().ForMember(dest => dest.permissions!.Select(x => x.Id), opt => opt.MapFrom(c => c.permissionsId));
        CreateMap<Role, RoleUpdateDTO>().ForMember(dest => dest.permissionsId, opt => opt.MapFrom(c => c.permissions!.Select(x => x.Id)));

        CreateMap<RoleGetDTO, Role>().ForMember(dest => dest.permissions!.Select(x => x.Id), opt => opt.MapFrom(c => c.permissionsId));
        CreateMap<Role, RoleGetDTO>().ForMember(dest => dest.permissionsId, opt => opt.MapFrom(c => c.permissions!.Select(x => x.Id)));
    }


    void CategoryMapping()
    {
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        CreateMap<CategoryGetDTO, Category>().ForMember(dest => dest.Books!.Select(x => x.Id), opt => opt.MapFrom(x => x.BooksId));
        CreateMap<Category, CategoryGetDTO>().ForMember(dest => dest.BooksId, opt => opt.MapFrom(c=>c.Books!.Select(x => x.Id)));
    }

    void UserMapping()
    {
        CreateMap<UserCreateDTO, User>().ReverseMap();

        CreateMap<UserUpdateDTO, User>().ForMember(dest => dest.Roles!.Select(x => x.Id), opt => opt.MapFrom(x => x.RolesId));
        CreateMap<User, UserUpdateDTO>().ForMember(dest => dest.RolesId, opt => opt.MapFrom(x=>x.Roles!.Select(x => x.Id)));
        
        CreateMap<UserGetDTO, User>().ForMember(dest => dest.Roles!.Select(x => x.Id), opt => opt.MapFrom(x => x.RolesId));
        CreateMap<User, UserGetDTO>().ForMember(dest => dest.RolesId, opt => opt.MapFrom(x=>x.Roles!.Select(x => x.Id)));
    }

    void PermissionMapping()
    {
        CreateMap<PermissionGetDTO, Permission>().ReverseMap();
    }

}




