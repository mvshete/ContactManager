using AutoMapper;
using ContactsWebApi.Application.Model;
using ContactsWebApi.Controllers;
using ContactsWebApi.Domain.Interface;
using ContactsWebApi.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;

namespace ContactsWebApi.Tests
{
    [TestClass]
    public class ContactsControllerTests
    {
        private ContactsController _sut;
        private Mock<IContactService> _mockContactService;

        [TestInitialize]
        public void SetUp()
        {
            _mockContactService = new Mock<IContactService>();
            _sut = new ContactsController(_mockContactService.Object)
            {
                Request = new HttpRequestMessage
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
        }

        [TestMethod]
        public void Get_When_Called_Then_Call_List_AsExpected()
        {
            //Arrange
           Mapper.Initialize(cfg => cfg.CreateMap<Contact, ContactDto>());
           
            var contactList = new List<Contact>
            {
                new Contact
                    {
                        Id=1,
                        FirstName = "Ajay",
                        LastName = "Patil",
                        Email = "ajay.patil@gmail.com",
                        Phone = "9000000000",
                        Status = true
                    },
                    new Contact
                    {
                        Id=2,
                        FirstName = "Amit",
                        LastName = "Patil",
                        Email = "amit.patil@gmail.com",
                        Phone = "9100000000",
                        Status = true
                    }
            };

            _mockContactService.Setup(x => x.List()).Returns(contactList);

            var result = _sut.Get();

            Assert.AreEqual(result.Count, contactList.Count);

            _mockContactService.Verify(x => x.List(), Times.Once);
        }

        [TestMethod]
        public void Post_When_Called_Then_Call_ServicePost_AsExpected()
        {
            //Arrange         
            var contactToSave = new ContactDto
            {
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };

            _mockContactService.Setup(x => x.Post(It.IsAny<Contact>())).Returns(0);

            var result = _sut.Post(contactToSave);
            var message = result as ResponseMessageResult;

            Assert.AreEqual(message.Response.StatusCode, HttpStatusCode.Created);

            _mockContactService.Verify(x => x.Post(It.IsAny<Contact>()), Times.Once);
        }

        [TestMethod]
        public void Put_When_Called_Then_Call_ServicePut_AsExpected()
        {
            //Arrange         
            var contactToUpdate = new ContactDto
            {               
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };

            _mockContactService.Setup(x => x.Put(It.IsAny<Contact>())).Returns(0);

            var result = _sut.Put(contactToUpdate,1);
            var message = result as ResponseMessageResult;

            Assert.AreEqual(message.Response.StatusCode, HttpStatusCode.Created);

            _mockContactService.Verify(x => x.Put(It.IsAny<Contact>()), Times.Once);
        }

        [TestMethod]
        public void Delete_When_Called_Then_Call_ServiceDelete_AsExpected()
        {
            //Arrange     
            _mockContactService.Setup(x => x.Delete(It.IsAny<int>())).Returns(0);

            var result = _sut.Delete(1);
            var message = result as ResponseMessageResult;

            Assert.AreEqual(message.Response.StatusCode, HttpStatusCode.OK);

            _mockContactService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
