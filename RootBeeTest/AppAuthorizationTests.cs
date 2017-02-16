using Microsoft.VisualStudio.TestTools.UnitTesting;
using HyperMock;
using RootBee;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace RootBeeTest
{
    [TestClass()]
    public class AppAuthorizationTests
    {
        [TestInitialize]
        public void BeforeEachTest()
        {
            //_mockService = Mock.Create<IAccountService>();
            //_controller = new AccountController(_mockService.Object);
        }

        [TestMethod()]
        public async Task GetVeryFirstTokenAsyncTest()
        {
            string APP_KEY = "6DUypFBjrvA5HshRS96Q6anmkbvPZRog";
            string code = GetPin();
            if (code != string.Empty)
            {
                Stopwatch sw = new Stopwatch();

                for (int i = 0; i < 60; i++)
                {
                    try
                    {
                        sw.Start();
                        EcobeeTokenRefresh token = new AppAuthorization().GetVeryFirstTokenAsync(code).Result;
                    }
                    catch (System.Exception ex  )
                    {
                        Debug.WriteLine(ex.InnerException.Message);
                        Debug.WriteLine(sw.Elapsed.TotalSeconds);
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                    
                }
                

                //Assert.IsNotNull(token.access_token);
            }
            
            
        }

        private string GetPin()
        {
            AppAuthorization auth = new AppAuthorization();
            EcobeeAPIPin pin = auth.GetPinAsync().Result;
            if (pin.code != null)
            {
                return pin.code;
            }
            return string.Empty;
        }

    }
}