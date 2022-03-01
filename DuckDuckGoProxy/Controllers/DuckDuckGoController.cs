using DuckDuckGoProxy.Application.Managers;
using DuckDuckGoProxy.Application.Persistence;
using DuckDuckGoProxy.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckDuckGoController : ControllerBase
    {
        private readonly IDuckDuckGoManager _duckDuckGoManager;

        public DuckDuckGoController(IDuckDuckGoManager duckDuckGoManager)
        {
            _duckDuckGoManager = duckDuckGoManager; 
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> Search([FromQuery] SearchRequest request)
        {
            var result = await _duckDuckGoManager.Search(request);
            return Ok(result);
        }
        [HttpGet]
        [Route("history")]
        public async Task<ActionResult<SearchResponse>> GetHistory()
        {
            var result = await _duckDuckGoManager.GetHistory();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/history")]
        public async Task<ActionResult<SearchResponse>> SaveHistory([FromBody] SaveHistoryRequest request)
        {
            var saveResult = await _duckDuckGoManager.SaveHistory(request);
            return Ok();
        }
    }
}
