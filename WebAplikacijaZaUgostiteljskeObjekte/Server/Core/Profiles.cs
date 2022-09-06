using AutoMapper;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core.Entities;
using WebAplikacijaZaUgostiteljskeObjekte.Shared;

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Core
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<User, UserModel>();
            CreateMap<CreateUser, User>().ReverseMap();
            CreateMap<Comment, CommentModel>();
            CreateMap<AddComment, Comment>().ReverseMap();
            CreateMap<UgostiteljskiObjekti, UgostiteljskiObjektiModel>().ReverseMap();
            CreateMap<CreateUO, UgostiteljskiObjekti>().ReverseMap();
            CreateMap<Jela,DishModel>().ReverseMap();
            CreateMap<CreateDish, Jela>().ReverseMap();
            CreateMap<AddGrade, Ocjene>().ReverseMap();
            CreateMap<Ocjene, OcjeneModel>().ReverseMap();
            CreateMap<Admin, AdminModel>().ReverseMap();
            CreateMap<PrijavljeniBugovi, BugModel>().ReverseMap();
            CreateMap<Drinks, DrinksModel>().ReverseMap();
        }
    }
}
