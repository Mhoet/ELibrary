using AutoMapper;

namespace ELibrary.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Model.DTO.RequestDTO.RegistrationRequestDTO, Model.User>();

            CreateMap<Model.User, Model.DTO.ResponseDTO.UserResponseDTO>();

            CreateMap<Model.User, Model.DTO.ResponseDTO.LoginResponseDTO>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src =>
                            $"{src.FirstName} {src.LastName}"));
        }
    }
}