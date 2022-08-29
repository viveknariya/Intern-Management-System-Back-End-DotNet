using Autofac.Extras.Moq;
using InternManagementSystem.BusinessLogic;
using InternManagementSystem.Controllers;
using InternManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;

namespace TestCase
{
    [TestClass]
    public class Test
    {
       
        [TestMethod]
        public void InternLogin()
        {

            using (var mock = AutoMock.GetLoose())
            {
                Login login = new Login { UserName = "test", Password = "test" };

                InternRecord intern = new InternRecord { InternId = "test", InternPassword = "test" };
                mock.Mock<IIntern>()
                    .Setup(x => x.Login(login))
                    .Returns(intern);

                var cls = mock.Create<InternRecordController>();

                var result = cls.Login(login) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void InternRecord()
        {

            using (var mock = AutoMock.GetLoose())
            {

                InternRecord intern = new InternRecord { InternId = "test", InternPassword = "test" };
                mock.Mock<IIntern>()
                    .Setup(x => x.InternRecord("test"))
                    .Returns(intern);

                var cls = mock.Create<InternRecordController>();

                var result = cls.InternRecord("test") as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }       

        [TestMethod]
        public void EditInternRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {

                InternRecord intern = new InternRecord { InternId = "vivektest", InternPassword = "vivektest", InternName = "newvivektest" };
                mock.Mock<IIntern>()
                    .Setup(x => x.PutRecord(intern))
                    .Returns(intern);

                var cls = mock.Create<InternRecordController>();

                var result = cls.PutRecord(intern) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void InternAddRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                InternRecord intern = new InternRecord { InternId = "test", InternPassword = "test" };
                mock.Mock<IIntern>()
                    .Setup(x => x.AddRecord(intern))
                    .Returns(intern);

                var cls = mock.Create<InternRecordController>();

                var result = cls.AddRecord(intern) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }
            
        }

        [TestMethod]
        public void InternDeleteRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                InternRecord intern = new InternRecord { InternId = "test", InternPassword = "test" };
                mock.Mock<IIntern>()
                    .Setup(x => x.DeleteRecord("test"))
                    .Returns(intern);

                var cls = mock.Create<InternRecordController>();

                var result = cls.DeleteRecord("test") as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void DesignationRecord()
        {

            using (var mock = AutoMock.GetLoose())
            {

                Designation designation = new Designation { DesignationName = "tester", RoleName = "testing" };
                mock.Mock<IDesignation>()
                    .Setup(x => x.DesignationRecord(10))
                    .Returns(designation);

                var cls = mock.Create<DesignationController>();

                var result = cls.DesignationRecord(10) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void EditDesignationRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {

                Designation designation = new Designation { DesignationName = "tester", RoleName = "testing" };
                mock.Mock<IDesignation>()
                    .Setup(x => x.PutRecord(designation))
                    .Returns(designation);

                var cls = mock.Create<DesignationController>();

                var result = cls.PutRecord(designation) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void DesignationAddRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Designation designation = new Designation { DesignationName = "tester", RoleName = "testing" };
                mock.Mock<IDesignation>()
                    .Setup(x => x.AddRecord(designation))
                    .Returns(designation);

                var cls = mock.Create<DesignationController>();

                var result = cls.AddRecord(designation) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void DesignationDeleteRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Designation designation = new Designation { DesignationName = "tester", RoleName = "testing" };
                mock.Mock<IDesignation>()
                    .Setup(x => x.DeleteRecord(10))
                    .Returns(designation);

                var cls = mock.Create<DesignationController>();

                var result = cls.DeleteRecord(10) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }


        [TestMethod]
        public void LeavebyIntern(string id)
        {
            using (var mock = AutoMock.GetLoose())
            {
                List<Leave> leave = new List<Leave>();
                leave.Add(new Leave { LeaveId = 10, LeaveDate = new System.DateTime(2020, 09, 09), Reason = "sick", InternId = "test" });
                mock.Mock<ILeave>()
                    .Setup(x => x.LeaveByIntern("test"))
                    .Returns(leave);

                var cls = mock.Create<LeaveController>();

                var result = cls.LeavebyIntern("test") as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }
        }

        [TestMethod]
        public void LeaveRecord(int id)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Leave leave = new Leave { LeaveId = 10, LeaveDate = new System.DateTime(2020, 09, 09), Reason = "sick", InternId = "test" };
                mock.Mock<ILeave>()
                    .Setup(x => x.LeaveRecord(10))
                    .Returns(leave);

                var cls = mock.Create<LeaveController>();

                var result = cls.LeaveRecord(10) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }
        }

        [TestMethod]
        public void AddRecord()
        {

            using (var mock = AutoMock.GetLoose())
            {
                Leave leave = new Leave { LeaveId = 10, LeaveDate = new System.DateTime(2020, 09, 09), Reason = "sick", InternId = "test" };

                mock.Mock<ILeave>()
                    .Setup(x => x.AddRecord(leave))
                    .Returns(leave);

                var cls = mock.Create<LeaveController>();

                var result = cls.AddRecord(leave) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }
        }

        [TestMethod]
        public void DeleteRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Leave leave = new Leave { LeaveId = 10, LeaveDate = new System.DateTime(2020, 09, 09), Reason = "sick", InternId = "test" };

                mock.Mock<ILeave>()
                    .Setup(x => x.DeleteRecord(10))
                    .Returns(leave);

                var cls = mock.Create<LeaveController>();

                var result = cls.DeleteRecord(10) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }

        [TestMethod]
        public void PutRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Leave leave = new Leave { LeaveId = 10, LeaveDate = new System.DateTime(2020, 09, 09), Reason = "sick", InternId = "test" };

                mock.Mock<ILeave>()
                    .Setup(x => x.PutRecord(leave))
                    .Returns(leave);

                var cls = mock.Create<LeaveController>();

                var result = cls.PutRecord(leave) as OkObjectResult;

                Assert.AreEqual(200, result.StatusCode);

            }

        }
    }
}
