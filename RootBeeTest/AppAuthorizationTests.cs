using HyperMock;
using RootBee;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using Xunit;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RootBeeTest
{
    public class AppAuthorizationTests
    {

        //public void GetVeryFirstTokenAsyncTest()
        //{
        //    string code = GetPin();
        //    if (code != string.Empty)
        //    {

        //        try
        //        {
        //            token = new AppAuthorization().GetVeryFirstTokenAsync(code).Result;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            Debug.WriteLine(ex.InnerException.Message);
        //        }

        //        Assert.NotNull(token.access_token);
        //    }


        //}

        //private string GetPin()
        //{
        //    AppAuthorization auth = new AppAuthorization();
        //    EcobeeAPIPin pin = auth.GetPinAsync().Result;
        //    if (pin.code != null)
        //    {
        //        return pin.code;
        //    }
        //    return string.Empty;
        //}

        //static EcobeeTokenRefresh token;

        //[Fact]
        //public void GetNewTokenAsyncTest()
        //{
        //    string assemblyName = "RootBee";
        //    string[] passArray = CredentialStorage.GetCredentialFromLocker(assemblyName);

        //    AppAuthorization appAuth = new AppAuthorization();
        //    EcobeeTokenRefresh token = appAuth.GetTokenRefreshAsync(passArray[1]).Result;


        //    CredentialStorage.DeleteCredentialFromLocker(assemblyName, passArray[0], passArray[1]);
        //    CredentialStorage.CreateCredentialInLocker(assemblyName, token.access_token, token.refresh_token);
        //}

        //[Fact]
        //public void WholePinTokenRefreshTest()
        //{
        //    DeleteCred();

        //    string code = GetPin();
        //    token = new AppAuthorization().GetVeryFirstTokenAsync(code).Result;

        //    AppAuthorization appauth = new AppAuthorization();
        //    token = appauth.GetTokenRefreshAsync(token.refresh_token).GetAwaiter().GetResult();
        //    CredentialStorage.CreateCredentialInLocker("RootBee", token.access_token, token.refresh_token);
        //}

        //private void DeleteCred()
        //{
        //    string assemblyName = "RootBee";
        //    string[] passArray = CredentialStorage.GetCredentialFromLocker(assemblyName);
        //    if (passArray[0] != string.Empty)
        //    {
        //        CredentialStorage.DeleteCredentialFromLocker(assemblyName, passArray[0], passArray[1]);
        //    }
        //}

        //[Fact]
        //public void GetTemperature()
        //{
        //    string json = "{\"selection\":{\"selectionType\":\"registered\",\"selectionMatch\":\"\",\"includeRuntime\":true}}";

        //    string assemblyName = "RootBee";
        //    string[] passArray = CredentialStorage.GetCredentialFromLocker(assemblyName);
        //    string authCode = passArray[0];

        //    AppAuthorization appauth = new AppAuthorization();
        //    string response = appauth.PostAPIFromSite(@"1/thermostat?json=", "spmkRzm6NPOER0PyZRxleBiKoGdHxjZP", json).GetAwaiter().GetResult();
        //    Debug.WriteLine(response);

        //}
    }
}