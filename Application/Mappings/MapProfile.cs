using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.DTOs.Categories;
using Application.DTOs.Commentaries;
using Application.DTOs.Permissions;
using Application.DTOs.Roles;
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


        PermissionMapping();
        UserMapping();
    }
    void AuthorMapping()
    {
        CreateMap<AuthorCreateDTO, Author>().ReverseMap();
        CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
        CreateMap<Author, AuthorGetDTO>().ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src!.Books!.Select(x => x.Id)));
        CreateMap<AuthorGetDTO, Author>().ForMember(dest => dest.Books!, opt => opt.MapFrom(src => src.BookIds!.Select(id => new Book() { Id = id })));
    }

    void BookMapping()
    {
        CreateMap<BookCreateDTO, Book>().ReverseMap();
        CreateMap<BookUpdateDTO, Book>().ReverseMap();
        CreateMap<BookGetDTO, Book>().ForMember(dest => dest.Commentaries!, opt => opt.MapFrom(c => c.CommentaryIds!.Select(id => new Commentary() { Id = id })));
        CreateMap<Book, BookGetDTO>().ForMember(dest => dest.CommentaryIds!, opt => opt.MapFrom(c => c.Commentaries!.Select(c => c.Id)));
    }

    void CommentaryMappping()
    {
        CreateMap<CommentaryCreateDTO, Commentary>().ReverseMap();
        CreateMap<CommentaryUpdateDTO, Commentary>().ReverseMap();
        CreateMap<CommentaryGetDTO, Commentary>().ReverseMap();
    }

    void RoleMapping()
    {
        CreateMap<RoleCreateDTO, Role>().ForMember(dest => dest.permissions!, opt => opt.MapFrom(c => c.permissionIds!.Select(id => new Permission() { Id = id })));
        CreateMap<Role, RoleCreateDTO>().ForMember(dest => dest.permissionIds, opt => opt.MapFrom(c => c.permissions!.Select(x => x.Id)));

        CreateMap<RoleUpdateDTO, Role>().ForMember(dest => dest.permissions!, opt => opt.MapFrom(c => c.permissionIds!.Select(id => new Permission() { Id = id })));
        CreateMap<Role, RoleUpdateDTO>().ForMember(dest => dest.permissionIds, opt => opt.MapFrom(c => c.permissions!.Select(x => x.Id)));

        CreateMap<RoleGetDTO, Role>().ForMember(dest => dest.permissions!, opt => opt.MapFrom(c => c.permissionIds!.Select(id => new Permission() { Id = id })));
        CreateMap<Role, RoleGetDTO>().ForMember(dest => dest.permissionIds, opt => opt.MapFrom(c => c.permissions!.Select(x => x.Id)));
    }


    void CategoryMapping()
    {
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        CreateMap<CategoryGetDTO, Category>().ForMember(dest => dest.Books!, opt => opt.MapFrom(x => x.BookIds!.Select(id => new Book() { Id = id })));
        CreateMap<Category, CategoryGetDTO>().ForMember(dest => dest.BookIds, opt => opt.MapFrom(c => c.Books!.Select(x => x.Id)));
    }

    void UserMapping()
    {
        CreateMap<UserCreateDTO, User>().ReverseMap();

        CreateMap<UserGetDTO, User>().ForMember(dest => dest.Roles, opt => opt.MapFrom(x => x.RoleIds!.Select(id => new Role() { Id = id })));
        CreateMap<User, UserGetDTO>().ForMember(dest => dest.RoleIds, opt => opt.MapFrom(x => x.Roles!.Select(x => x.Id)));
    }

    void PermissionMapping()
    {
        CreateMap<PermissionGetDTO, Permission>().ReverseMap();
    }

}




