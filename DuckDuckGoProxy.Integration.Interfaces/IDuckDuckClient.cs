using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Integration.Interfaces
{
    public interface IDuckDuckClient<TRequest, TResponse>
    {
        Task<TResponse> GetAsync(TRequest request);
    }
}
