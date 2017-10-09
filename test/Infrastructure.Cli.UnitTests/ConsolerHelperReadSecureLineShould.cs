using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Cli.Utils;
using System.Threading.Tasks;
using System.Threading;
using System.Security;

namespace Infrastructure.Cli.UnitTests
{
    [TestClass]
    public class ConsolerHelperReadSecureLineShould
    {
        [TestMethod]
        [Ignore]
        public void ReadConsoleInputIntoSecureString()
        {
            SecureString testSecureLine = null;
            
            var readSecureTask = Task.Run(() => {
                testSecureLine = ConsoleHelper.ReadSecureLine();
            });

            Thread.Sleep(1000);

            // TODO: Attempting to mimic typing to the console to test `ReadSecureLine`,
            // but this doesn't work (hence IgnoreAttribute)
            Console.SetIn(new StringReader("abc\r\n"));

            readSecureTask.ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.IsNotNull(testSecureLine, "testSecureLine never set.");
            Assert.IsTrue(testSecureLine.IsReadOnly(), "testSecureLine is not readonly.");
            Assert.AreEqual(3, testSecureLine.Length);
        }
    }
}
