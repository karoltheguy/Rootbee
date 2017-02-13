using Microsoft.VisualStudio.TestTools.UnitTesting;
using RootBee;
using Windows.Security.Credentials;

namespace RootBeeTest
{
    [TestClass()]
    public class CredentialStorageTest
    {

        string CredentialName = "EcobeeTest";
        string username = "testUsername";
        string password = "testPassword";

        CredentialStorage credentialStorage = new CredentialStorage();

        [TestMethod()]
        [TestCategory("Credential")]
        public void TestCredentialFromLockerMethodsTest()
        {
            credentialStorage.CreateCredentialInLocker(CredentialName, username, password);
            if (!CanGetCredential()) Assert.Fail("Could not get credential after being created.");
            credentialStorage.DeleteCredentialFromLocker(CredentialName, username, password);
            if (CanGetCredential()) Assert.Fail("Credential still exist after being deleted.");

        }

        private bool CanGetCredential()
        {
            try
            {
                string[] passResultArray = credentialStorage.GetCredentialFromLocker(CredentialName);

                if (!passResultArray[0].Equals(username))
                {
                    Assert.Fail("Username in storage is {0} and does not equal to pre-populated {1}", passResultArray[0], username);
                }
                if (!passResultArray[1].Equals(password))
                {
                    Assert.Fail("Password in storage is {0} and does not equal to pre-populated {1}", passResultArray[1], password);
                }
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

    }
}
