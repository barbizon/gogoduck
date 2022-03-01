using DuckDuckGoProxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Application.Managers
{
    public interface IDuckDuckGoManager
    {
        Task<SearchResponse> Search(SearchRequest request);
        Task<HistoryResponseItem> SaveHistory(SaveHistoryRequest request);
        Task<HistoryResponse> GetHistory();
    }
}
