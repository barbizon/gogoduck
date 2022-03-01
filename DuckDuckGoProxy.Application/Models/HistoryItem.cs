using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Application.Persistence.Models
{
    public class HistoryItem
    {
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
        public string Query { get; set; }
    }
}
