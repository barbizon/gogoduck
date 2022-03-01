using System;
using System.Collections.Generic;

namespace DuckDuck.ViewModels
{
    //public class DuckDuckResponse
    //{
    //    public IList<SearchItem> RelatedTopics { get; set; }
    //}
    public class DuckDuckResponse
    {
        public IList<RelatedTopic> RelatedTopics { get; set; }
    }

    public class RelatedTopic
    {
        public string Name { get; set; }
        public IList<SearchItem> Topics { get; set; }
    }
}
