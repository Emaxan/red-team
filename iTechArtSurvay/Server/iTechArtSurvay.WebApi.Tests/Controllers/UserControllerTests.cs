using iTechArtSurvay.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iTechArtSurvay.WebApi.Controllers.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void GetUserTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AddUserTest()
        {
            //arrange

            //act
            var control = new UsersController();
            control.AddUser(new User {Email = "email", Id = 1, Name = "name", Password = "password"});
            //accert
            Assert.AreEqual(true, true);
        }
    }
}