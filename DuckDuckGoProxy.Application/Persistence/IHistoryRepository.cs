using DuckDuckGoProxy.Application.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Application.Persistence
{
    public interface IHistoryRepository
    {
        IList<HistoryItem> GetList();
        HistoryItem Save(HistoryItem item);
    }
}