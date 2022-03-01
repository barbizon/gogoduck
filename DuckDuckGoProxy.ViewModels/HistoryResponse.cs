using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.ViewModels
{
    public class HistoryResponse
    { 
        public IList<HistoryResponseItem> Items { get; set; }
    }
}
