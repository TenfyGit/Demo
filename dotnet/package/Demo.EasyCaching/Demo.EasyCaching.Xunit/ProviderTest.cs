using EasyCaching.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Xunit;

namespace Demo.EasyCaching.Xunit
{
    public class ProviderTest: BaseProviderTest
    {
        public ProviderTest()
        {
            
        }
        protected override IEasyCachingProvider CreateCachingProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddEasyCaching(option =>
            {
                //option.UseInMemory("default");//MaxRdSecond默认为120s
                option.UseInMemory(op =>
                {
                    op.MaxRdSecond = 0;//最大随机秒数，如果MaxRdSecond大于0，缓存到期时间将随机增加
                }, "default");
            });
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var provider = serviceProvider.GetService<IEasyCachingProvider>();
            return provider;
        }
        /// <summary>
        /// 测试Get方法
        /// </summary>
        /// <param name="cacheKey">缓存键</param>
        /// <param name="defaultValue">在缓存中不存在时返回的默认值</param>
        [Theory]
        [InlineData("key_get", "123")]
        public void Get_Default_IsTrue(string cacheKey,string defaultValue)
        {
            string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _provider.Remove(cacheKey);
            string result = _provider.Get(cacheKey, () => defaultValue, TimeSpan.FromSeconds(10)).Value;
            Assert.Equal(defaultValue,result);
            _provider.Set(cacheKey, value, TimeSpan.FromSeconds(1));
            result = _provider.Get<string>(cacheKey).Value;
            Assert.Equal(value,result);
        }
        /// <summary>
        /// 测试Get方法-过期条件
        /// </summary>
        /// <param name="cacheKey">缓存键</param>
        [Theory]
        [InlineData("key_get2")]
        public void Get_AfterExpiration_IsNull(string cacheKey)
        {
            string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _provider.Set(cacheKey, value, TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            string result = _provider.Get<string>(cacheKey).Value;
            Assert.Null(result);
        }
        /// <summary>
        /// 测试Exists方法-过期条件
        /// </summary>
        /// <param name="cacheKey">缓存键</param>
        [Theory]
        [InlineData("key_exists")]
        public void Exists_AfterExpiration_IsFault(string cacheKey)
        {
            string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _provider.Set(cacheKey, value, TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(1));
            bool isExist = _provider.Exists(cacheKey);
            Assert.False(isExist);
        }

    }
}
