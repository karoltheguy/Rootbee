using Xunit;
using RootBee;
using Windows.Security.Credentials;

namespace RootBeeTest
{
    public class CredentialStorageTest
    {

        string CredentialName = "EcobeeTest";
        string username = "testUsername";
        string password = "testPassword";

        [Fact]
        //[TestCategory("Credential")]
        public void TestCredentialFromLockerMethodsTest()
        {
            CredentialStorage.CreateCredentialInLocker(CredentialName, username, password);
            Assert.True(CanGetCredential(), "Could not get credential after being created.");
            CredentialStorage.DeleteCredentialFromLocker(CredentialName, username, password);
            Assert.False(CanGetCredential(), "Credential still exist after being deleted.");
        }

        private bool CanGetCredential()
        {
            try
            {
                string[] passResultArray = CredentialStorage.GetCredentialFromLocker(CredentialName);

                Assert.True(passResultArray[0].Equals(username), string.Format("Username in storage is {0} and does not equal to pre-populated {1}", passResultArray[0], username));

                Assert.True(passResultArray[1].Equals(password), string.Format("Password in storage is {0} and does not equal to pre-populated {1}", passResultArray[1], password));
                
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

    }
}
