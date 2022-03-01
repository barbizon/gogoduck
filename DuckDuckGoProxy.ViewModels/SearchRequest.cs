using System;

namespace DuckDuckGoProxy.ViewModels
{
    public class SearchRequest
    {
        public string Q { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
