using AutoMapper;
using DuckDuck.ViewModels;
using DuckDuckGoProxy.Application.Persistence;
using DuckDuckGoProxy.Application.Persistence.Models;
using DuckDuckGoProxy.Configuration;
using DuckDuckGoProxy.Integration.Interfaces;
using DuckDuckGoProxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Application.Managers
{
    public class DuckDuckGoManager : IDuckDuckGoManager
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IDuckDuckClient<DuckDuckRequest, DuckDuckResponse> _duckDuckClient;
        private readonly IHistoryRepository _historyRepository;

        public DuckDuckGoManager(IMapper mapper, AppSettings appSettings, IHistoryRepository historyRepository,
            IDuckDuckClient<DuckDuckRequest, DuckDuckResponse> duckDuckClient)
        {
            _mapper = mapper;
            _appSettings = appSettings;
            _duckDuckClient = duckDuckClient;
            _historyRepository = historyRepository;
        }

        public async Task<HistoryResponse> GetHistory()
        {
            var getResult = _historyRepository.GetList();
            var mappedResponse = _mapper.Map<List<HistoryResponseItem>>(getResult);

            return new HistoryResponse { Items = mappedResponse };
        }

        public async Task<HistoryResponseItem> SaveHistory(SaveHistoryRequest request)
        {
            var mappedRequest = _mapper.Map<HistoryItem>(request);
            var saveResult = _historyRepository.Save(mappedRequest);
            var mappedResponse = _mapper.Map<HistoryResponseItem>(saveResult);

            return mappedResponse;
        }

        public async Task<SearchResponse> Search(SearchRequest request)
        {
            var mappedRequest = _mapper.Map<DuckDuckRequest>(request);
            var duckDuckProviderResult = await _duckDuckClient.GetAsync(mappedRequest);
            var pageSize = request.PageSize == 0 ? _appSettings.DefaultPageSize : request.PageSize;
            var totalItems = duckDuckProviderResult.RelatedTopics
                .Sum(rt => rt.Topics == null ? 0 : rt.Topics.Count);
            var flatResult = duckDuckProviderResult.RelatedTopics.Where(t => t.Topics != null)
                .SelectMany(t => t.Topics).Skip(request.Page * pageSize).Take(pageSize);             
            var items = _mapper.Map<IList<SearchResponseItem>>(flatResult);

            var mappedHistoryItem = _mapper.Map<HistoryItem>(request);

            if (request.Page == 0)
            {
                var historyItem = _historyRepository.Save(mappedHistoryItem);
            }
            return new SearchResponse { Items = items, ResultsCount = totalItems };
        }
    }
}
