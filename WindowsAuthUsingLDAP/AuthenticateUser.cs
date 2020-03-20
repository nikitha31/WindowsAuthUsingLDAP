using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Web;

namespace WindowsAuthUsingLDAP
{
    public static class AuthenticateUser
    {
        /// <summary>
        /// A function to validate user credentials using windows authentication
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns>whether the user is valid or not</returns>
        public static bool IsValidUser(string userName,string passWord)
        {
            bool isValid;
            try
            {
                //The LdapConnection class creates a TCP/IP(false) or udp(true) LDAP connection to Microsoft Active Directory
                // Domain Services or an LDAP server using the special directory identifier(serverID,isFullyQualifiedDNShostName,tcp or udp).
                LdapConnection ldapConnection = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                NetworkCredential networkCredential = new NetworkCredential(userName, passWord, "PRINCETON");
                ldapConnection.Credential = networkCredential;
                //Negotiate is a Microsoft Windows authentication mechanism that uses 
                //Kerberos as its underlying authentication provider.
                ldapConnection.AuthType = AuthType.Negotiate;
                ldapConnection.Bind(networkCredential);
                isValid = true;
            }
            catch(LdapException ldapException)
            {
                isValid = false;
                Debug.Print(ldapException.Message);
            }
            return isValid;
        }
    }
}