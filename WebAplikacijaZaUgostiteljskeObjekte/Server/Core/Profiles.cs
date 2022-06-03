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
            CreateMap<UgostiteljskiObjekti, UgostiteljskiObjektiModel>().ReverseMap();
        }
    }
}
