using EasyCaching.Core.Interceptor;
using System;

namespace Demo.EasyCaching.IService
{
    public interface IDemoService
    {
        [EasyCachingAble(Expiration = 10, CacheKeyPrefix = "Castle")]
        string GetCurrentUtcTime();

        [EasyCachingPut(CacheKeyPrefix = "Castle")]
        string PutSomething(string str);

        [EasyCachingEvict(CacheKeyPrefix = "Castle",IsBefore = true)]
        void DeleteSomething(int id);
    }
}
