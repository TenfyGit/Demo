using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.EasyCaching.Xunit
{
    public abstract class BaseProviderTest
    {
        protected IEasyCachingProvider _provider;
        protected abstract IEasyCachingProvider CreateCachingProvider();
        public BaseProviderTest()
        {
            _provider = CreateCachingProvider();
        }
    }
}
