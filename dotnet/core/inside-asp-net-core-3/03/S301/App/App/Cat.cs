using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public class Cat
    {
        internal readonly ConcurrentDictionary<Type, ServiceRegistry> _registries;
        private volatile bool _disposed;
        public Cat()
        {
            _registries = new ConcurrentDictionary<Type, ServiceRegistry>();
        }
        public Cat Register(ServiceRegistry registry)
        {
            EnsureNotDisposed();
            if (_registries.TryGetValue(registry.ServiceType, out var existing))
            {
                _registries[registry.ServiceType] = registry;
                registry.Next = existing;
            }
            else
            {
                _registries[registry.ServiceType] = registry;
            }
            return this;
        }
        /// <summary>
        /// 确定Cat对象没有被释放
        /// </summary>
        private void EnsureNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(Cat));
            }
        }
        public object GetService(Type serviceType)
        {
            return null;
        }
    }
}
