using Application.Features.Streamers.Commands.CreateStreamer;
using Application.Features.Streamers.Queries.GetStreamerByName;
using Application.Features.Streamers.Commands.UpdateStreamer;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Streamer, StreamersVM>()
                     .ForMember(streamerVm => streamerVm.Name, streamer => streamer.MapFrom(src => src.Name))
                     .ForMember(streamerVm => streamerVm.Id, streamer => streamer.MapFrom(src => src.Id));
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<UpdateStreamerCommand,Streamer>()
                     .ForMember(streamer => streamer.Name, streamerCommand => streamerCommand.MapFrom(src => src.Name))
                     .ForMember(streamer => streamer.Id, streamerCommand => streamerCommand.MapFrom(src => src.Id));
        }
    }
}
