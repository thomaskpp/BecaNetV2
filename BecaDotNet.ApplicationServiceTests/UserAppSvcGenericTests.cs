using BecaDotNet.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BecaDotNet.ApplicationService.Tests
{
    [TestClass()]
    public class UserAppSvcGenericTests
    {
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }


        [TestMethod()]
        public void CreateTest()
        {
            var usr = new User
            {
                Email = "newusermail@mail.com",
                IsActive = true,
                Login = "newUser",
                Name = "New User",
                RegisterDate = DateTime.Now,
                Password = "dwp321",
                UserTypeId = 1
            };
            var svc = new UserAppSvcGeneric();
            var res = svc.Create(usr);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Id > 0);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void FindByTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            throw new NotImplementedException();
        }
    }
}