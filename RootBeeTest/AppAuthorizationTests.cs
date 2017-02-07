using Microsoft.VisualStudio.TestTools.UnitTesting;
using Etg.SimpleStubs;
using RootBee;

namespace RootBeeTest
{
    [TestClass]
    public class AppAuthorizationTests
    {
        //private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
         //   this.mockRepository = new MockRepository(MockBehavior.Strict);
         

        }

        [TestCleanup]
        public void TestCleanup()
        {
           // this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestMethod1()
        {


            AppAuthorization appAuthorization = this.CreateAppAuthorization();


        }

        private AppAuthorization CreateAppAuthorization()
        {
            return new AppAuthorization();
        }
    }
}