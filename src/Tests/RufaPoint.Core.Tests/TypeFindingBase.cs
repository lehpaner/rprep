using System;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests
{
    public abstract class TypeFindingBase : TestsBase
    {
        protected ITypeFinder typeFinder;

        protected abstract Type[] GetTypes();


        public TypeFindingBase():base()
        {
            typeFinder = new Fakes.FakeTypeFinder(typeof(TypeFindingBase).Assembly, GetTypes());
        }
    }
}
