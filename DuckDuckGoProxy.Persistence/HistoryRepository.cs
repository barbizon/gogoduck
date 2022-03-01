using DuckDuckGoProxy.Application.Persistence;
using DuckDuckGoProxy.Application.Persistence.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DuckDuckGoProxy.Persistence
{
    public class HistoryRepository : IHistoryRepository
    {
        public IList<HistoryItem> GetList()
        {
            List<HistoryItem> items = null;
            using (StreamReader r = new StreamReader(@"History\history.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<HistoryItem>>(json);
            }
            return items.OrderByDescending(i => i.AddedOn).ToList();
        }

        public HistoryItem Save(HistoryItem item)
        {
            var items = GetList();
            item.AddedOn = DateTime.Now;
            items.Add(item);
            var data = JsonConvert.SerializeObject(items);
            File.WriteAllText(@"History\history.json", data);
            return item;
        }
    }
}
