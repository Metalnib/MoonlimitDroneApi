using AutoMapper;
using Moonlimit.DroneAPI.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlimit.DroneAPI.Domain.Mapping
{
    public partial class MappingProfile : Profile
    {
        /// <summary>
        /// Create automap mapping profiles
        /// </summary>
        public MappingProfile()
        {
            CreateMap<CompanyAccountViewModel, CompanyAccount>()
                .ForMember(dest => dest.xmin, opts => opts.MapFrom(src => src.RowVersion));
            CreateMap<CompanyAccount, CompanyAccountViewModel>()
                .ForMember(dest => dest.RowVersion, opts => opts.MapFrom(src => src.xmin));
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.DecryptedPassword, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => string.Join(";", src.Roles)));
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.DecryptedPassword))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.Roles.Split(";", StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<Drone, DroneViewModel>().ReverseMap();
            CreateMap<Mission, MissionViewModel>().ReverseMap();
            CreateMap<BoardNetwork, BoardNetworkViewModel>().ReverseMap();
            CreateMap<DroneNetworkSettings, DroneNetworkSettingsViewModel>().ReverseMap();

            //call code in partial scaffolded function
            SetAddedMappingProfile();
        }

        //to call scaffolded method
        partial void SetAddedMappingProfile();

    }





}
