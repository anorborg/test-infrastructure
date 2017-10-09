using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Security;

namespace Infrastructure.Core.UnitTests
{
    [TestClass]
    public class SecureStringExtensionShould
    {
        SecureString testSecureString = new SecureString();

        [TestMethod]
        public void UnsecureString()
        {
            testSecureString.AppendChar('a');
            testSecureString.AppendChar('b');
            testSecureString.AppendChar('c');
            testSecureString.AppendChar('d');
            testSecureString.MakeReadOnly();

            var unsecure = testSecureString.ToUnsecureString();

            Assert.AreEqual("abcd", unsecure, "Unsecured string does not match value initial set in secure string");
        }
    }
}
