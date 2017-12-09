using System;
using RufaPoint.Core.Infrastructure;
using RufaPoint.Tests;
using NUnit.Framework;

namespace RufaPoint.Core.Tests
{
    public abstract class TypeFindingBase : TestsBase
    {
        protected ITypeFinder typeFinder;

        protected abstract Type[] GetTypes();

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            typeFinder = new Fakes.FakeTypeFinder(typeof(TypeFindingBase).Assembly, GetTypes());
        }
    }
}
