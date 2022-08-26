using InternManagementSystem.BusinessLogic;
using InternManagementSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCase
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void InternLogin()
        {
            Login login = new Login { UserName = "test", Password = "test" };

            InternRecord intern = new InternRecord { InternId = "test", InternPassword="test"};

            InternLogic internLogic = new InternLogic();

            var result = internLogic.Login(login);

            Assert.AreEqual(result.InternId, login.UserName);
            Assert.AreEqual(result.InternPassword, login.Password);
        }

        [TestMethod]
        public void InternRecord()
        {

            InternRecord intern = new InternRecord { InternId = "test", InternPassword = "test"};

            InternLogic internLogic = new InternLogic();

            var result = internLogic.InternRecord("test");

            Assert.AreEqual(result.InternPassword, internLogic.InternRecord("test").InternName);
        }       

        [TestMethod]
        public void EditInternRecord()
        {

            InternRecord intern = new InternRecord { InternId = "vivektest", InternPassword = "vivektest", InternName = "newvivektest" };

            InternLogic internLogic = new InternLogic();

            var result = internLogic.PutRecord(intern);

            Assert.AreEqual(result.InternName, internLogic.InternRecord("vivektest").InternName);
        }

    }
}
