using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace RootBee
{
    class CredentialStorage
    {
        private PasswordCredential GetCredentialFromLocker(string resourceName)
        {
            PasswordCredential credential = null;

            var vault = new PasswordVault();
            var credentialList = vault.FindAllByResource(resourceName);
            if (credentialList.Count > 0)
            {
                credential = credentialList[0];
            }
            else
            {
                return new PasswordCredential(resourceName, "", "");
            }

            return credential;
        }

        public void DeleteCredentialFromLocker(string resourceName, string username, string password)
        {
            var vault = new PasswordVault();
            vault.Remove(new PasswordCredential(resourceName, username, password));
        }

        public void CreateCredentialInLocker(string resourceName, string username, string password)
        {
            var vault = new PasswordVault();
            vault.Add(new PasswordCredential(resourceName, username, password));
        }
    }
}
