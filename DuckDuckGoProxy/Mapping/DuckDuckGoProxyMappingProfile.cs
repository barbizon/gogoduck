using AutoMapper;
using DuckDuck.ViewModels;
using DuckDuckGoProxy.Application.Persistence.Models;
using DuckDuckGoProxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Mapping
{
    public class DuckDuckGoProxyMappingProfile : Profile
    {
        public DuckDuckGoProxyMappingProfile()
        {
            CreateMap<SearchRequest, DuckDuckRequest>()
                .ForMember(d => d.Query, opt => opt.MapFrom(s => s.Q));

            CreateMap<SearchItem, SearchResponseItem>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Text))
                .ForMember(d => d.Url, opt => opt.MapFrom(s => s.FirstUrl));

            CreateMap<SearchRequest, HistoryItem>()
                .ForMember(d => d.Query, opt => opt.MapFrom(s => s.Q));

            CreateMap<HistoryItem, HistoryResponseItem>()
                .ForMember(d => d.Query, opt => opt.MapFrom(s => s.Query));
        } 
    }
}
