using HyperMock;
using RootBee;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using Xunit;

namespace RootBeeTest
{
    public class AppAuthorizationTests
    {

        public void GetVeryFirstTokenAsyncTest()
        {
            string code = GetPin();
            if (code != string.Empty)
            {

                try
                {
                    token = new AppAuthorization().GetVeryFirstTokenAsync(code).Result;
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.InnerException.Message);
                }

                Assert.NotNull(token.access_token);
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

        static EcobeeTokenRefresh token;

        [Fact]
        public void GetNewTokenAsyncTest()
        {
            string assemblyName = "RootBee";
            CredentialStorage credentialStorage = new CredentialStorage();
            string[] passArray = credentialStorage.GetCredentialFromLocker(assemblyName);

            AppAuthorization appAuth = new AppAuthorization();
            EcobeeTokenRefresh token = appAuth.GetTokenRefreshAsync(passArray[1]).Result;


            credentialStorage.DeleteCredentialFromLocker(assemblyName, passArray[0], passArray[1]);
            credentialStorage.CreateCredentialInLocker(assemblyName, token.access_token, token.refresh_token);
        }

        [Fact]
        public void WholePinTokenRefreshTest()
        {
            DeleteCred();

            string code = GetPin();
            token = new AppAuthorization().GetVeryFirstTokenAsync(code).Result;

            AppAuthorization appauth = new AppAuthorization();
            token = appauth.GetTokenRefreshAsync(token.refresh_token).GetAwaiter().GetResult();
            new CredentialStorage().CreateCredentialInLocker("RootBee", token.access_token, token.refresh_token);
        }

        private void DeleteCred()
        {
            string assemblyName = "RootBee";
            CredentialStorage credentialStorage = new CredentialStorage();
            string[] passArray = credentialStorage.GetCredentialFromLocker(assemblyName);
            if (passArray[0] != string.Empty)
            {
                credentialStorage.DeleteCredentialFromLocker(assemblyName, passArray[0], passArray[1]);
            }
        }
    }
}