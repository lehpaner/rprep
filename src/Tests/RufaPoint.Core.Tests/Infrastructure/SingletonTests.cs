using System;
using RufaPoint.Core.Infrastructure;
using Xunit;

namespace RufaPoint.Core.Tests.Infrastructure
{
    public class SingletonTests
    {
        [Fact]
        public void Singleton_IsNullByDefault()
        {
            var instance = Singleton<SingletonTests>.Instance;
            Assert.Null(instance);
        }

        [Fact]
        public void Singletons_ShareSame_SingletonsDictionary()
        {
            Singleton<int>.Instance = 1;
            Singleton<double>.Instance = 2.0;

            Assert.Same(Singleton<int>.AllSingletons, Singleton<double>.AllSingletons);
            Assert.Equal(Singleton.AllSingletons[typeof(int)], 1);
            Assert.Equal(Singleton.AllSingletons[typeof(double)], 2.0);
        }

        [Fact]
        public void SingletonDictionary_IsCreatedByDefault()
        {
            var instance = SingletonDictionary<SingletonTests, object>.Instance;
            Assert.NotNull(instance);
        }

        [Fact]
        public void SingletonDictionary_CanStoreStuff()
        {
            var instance = SingletonDictionary<Type, SingletonTests>.Instance;
            instance[typeof(SingletonTests)] = this;
            Assert.Same(instance[typeof(SingletonTests)], this);
        }

        [Fact]
        public void SingletonList_IsCreatedByDefault()
        {
            var instance = SingletonList<SingletonTests>.Instance;
            Assert.NotNull(instance);
        }

        [Fact]
        public void SingletonList_CanStoreItems()
        {
            var instance = SingletonList<SingletonTests>.Instance;
            instance.Insert(0, this);
            Assert.Same(instance[0], this);
        }
    }
}
