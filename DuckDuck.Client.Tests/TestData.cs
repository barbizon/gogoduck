using DuckDuck.ViewModels;
using DuckDuckGoProxy.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuck.Client.Tests
{
    public class TestData
    {
        public static DuckDuckSource DuckClientSourceConfigSuccess => new DuckDuckSource
        {
            Key = "DuckDuck",
            Url = "https://duckduckgo.com/"
        };
        public static DuckDuckRequest DuckDuckRequest => new DuckDuckRequest
        {
            Query = "Hello"
        };
    }
}
