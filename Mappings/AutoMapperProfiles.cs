using AutoMapper;
using Walks.API.Models.Domain;
using Walks.API.Models.DTO;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<RegionRequestDto, Region>().ReverseMap();
        CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
        CreateMap<Walk, WalkDto>().ReverseMap();
        CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        CreateMap<UpdateWalkReqDto, Walk>().ReverseMap();
    }
}

