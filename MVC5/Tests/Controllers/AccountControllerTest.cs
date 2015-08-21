//using System;
//using System.Web;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using ServiceLayer.Contracts;
//using ServiceLayer.Mailers;
//using NUnit.Framework;
//using Web.Controllers;

//namespace Tests.Controllers
//{
//    [TestFixture]
//    public class AccountControllerTest
//    {
//        #region Fields
//        private readonly IMappingEngine _mapperEngine;
//        private readonly HttpRequestBase _httpRequestBase;
//        private readonly IAuthenticationManager _authenticationManager;
//        private readonly IApplicationSignInManager _signInManager;
//        private readonly IApplicationUserManager _userManager;
//        private readonly IUserMailer _userMailer;
//        private Mock<IUserMailer> _mailerMock;
//        private AccountController _accountController;
//        #endregion


//        #region Configurations
//        [SetUp]
//        public void InitBeforeEachTest()
//        {
//            _mailerMock=new Mock<IUserMailer>();
//            _accountController=new AccountController();
//        }

//        [TearDown]
//        public void RunAfterEachTest()
//        {
//        }

//        [TestFixtureSetUp]
//        public void OneTimeSetUp()
//        {
//        }

//        [TestFixtureTearDown]
//        public void OneTimeTearDown()
//        {
//        }
//        #endregion

//        [Test]
//        public void Test_Send_ConfirmEmail_When_Register()
//        {

//        }

//    }
//}
