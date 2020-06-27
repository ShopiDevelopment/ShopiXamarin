using System;
using System.Threading;
using System.Threading.Tasks;

namespace _ShopiXamarin.Network
{
    public interface IOperations
    {
        Task<T> GetResponse<T>(string url, CancellationToken ctn);
        Task<T> PostJson<T>(string url, T myclass, CancellationToken ctn);
        Task<TU> PostJson<T, TU>(string url, T myclass, CancellationToken ctn, int timeoutSeconds = 0);
        Task<T> PutJson<T>(string url, T myclass, CancellationToken ctn);
        Task<TU> PutJson<T, TU>(string url, T myclass, CancellationToken ctn);
        Task<T> DeleteJson<T>(string url, CancellationToken ctn);
    }
}
