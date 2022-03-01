using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.ViewModels
{
    public class SearchResponse
    {
        public int ResultsCount { get; set; }
        public IList<SearchResponseItem> Items { get; set; }
    }
}
