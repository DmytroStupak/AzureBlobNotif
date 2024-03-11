using Moq;
using AzureBlobNotif.Interfaces;
using AzureBlobNotif;

namespace FunctionApp.Tests
{
    [TestClass]
    public class GmailTest
    {
        [TestMethod]
        public void WrongMailTest ()
        {
            var sasGener = new Mock<IUriSasGener>();
            var gmail = new Mock<IGmail>();
            var fileName = "asfwgqf.docx";
            sasGener.Setup(s => s.GetBlobSASTOkenByFile(It.IsAny<string>())).Returns("fhretgwadfv4ret4r");

            var res = gmail.Object.Send(fileName, sasGener.Object.GetBlobSASTOkenByFile(fileName));


            Assert.IsFalse(res);

        }

        [TestMethod]
        public void CorrectMailTest()
        {
            var gmail = new Mock<Gmail>();
            var fileName = "sqeq@gmail.com,asfwgqf.docx";
            var sasGener = "vfhretgwadfv4ret4r";

            var res = gmail.Object.Send(fileName, sasGener);

            Assert.IsTrue(res);

        }
    }
}