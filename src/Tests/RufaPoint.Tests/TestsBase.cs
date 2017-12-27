using System.Security.Principal;
using Xunit;

namespace RufaPoint.Tests
{
    public abstract class TestsBase
    {
        //Pekmez         protected MockRepository mocks;

        public TestsBase()
        {
            //Pekmez     mocks = new MockRepository();
        }

        public virtual void TearDown()
        {
            /*//Pekmez 
            if (mocks != null)
            {
                mocks.ReplayAll();
                mocks.VerifyAll();
            }*/
        }

        protected static IPrincipal CreatePrincipal(string name, params string[] roles)
        {
            return new GenericPrincipal(new GenericIdentity(name, "TestIdentity"), roles);
        }
    }
}
