using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace RootBee
{
    public class CredentialStorage
    {
        public static string[] GetCredentialFromLocker(string resourceName)
        {
            PasswordCredential credential = null;

            var vault = new PasswordVault();
            try
            {
                var credentialList = vault.FindAllByResource(resourceName);
                credential = credentialList[0];
                credential.RetrievePassword();
                return new string[] { credential.UserName, credential.Password };
            }
            catch (Exception)
            {
                return new string[] { "", "" };
            }
            
            //if (credentialList.Count > 0)
            //{
                
            //}
            //else
            //{
                
            //}

            
        }

        public static void DeleteCredentialFromLocker(string resourceName, string username, string password)
        {
            var vault = new PasswordVault();
            vault.Remove(new PasswordCredential(resourceName, username, password));
        }

        public static void CreateCredentialInLocker(string resourceName, string username, string password)
        {
            var vault = new PasswordVault();
            vault.Add(new PasswordCredential(resourceName, username, password));
        }

        public static void UpdateCredentialInLocker(string resourceName, string username, string password)
        {
            DeleteCredentialFromLocker(resourceName, username, password);
            CreateCredentialInLocker(resourceName, username, password);
        }
    }
}
