using ContactsWebApi.Data.Interface;
using ContactsWebApi.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace ContactsWebApi.Domain.Services.Tests
{
    [TestClass]
    public class ContactServiceTests
    {
        private ContactService _sut;
        private Mock<IContactRepository> _mockContactRepository;

        [TestInitialize]
        public void SetUp()
        {
            _mockContactRepository = new Mock<IContactRepository>();
            _sut = new ContactService(_mockContactRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContactRepository_WhenConstructed_WithANull_ThenThrows_AnArgumentNullException()
        {
            var contactService = new ContactService(null);
        }

        [TestMethod]
        public void List_When_Called_Then_Call_RepositoryList_AsExpected()
        {
            //Arrange  
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

            _mockContactRepository.Setup(x => x.List()).Returns(contactList);

            //Act
            var result = _sut.List();

            Assert.AreEqual(contactList.Count, result.Count);

            //Assert
            _mockContactRepository.Verify(x => x.List(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ContactServiceException))]
        public void List_When_Called_Throws_ContactServiceException()
        {
            //Arrange             
            _mockContactRepository.Setup(x => x.List()).Throws<ContactServiceException>();

            //Act
            _sut.List();
        }

        [TestMethod]
        public void Post_When_Called_Then_Call_RepositoryPost_AsExpected()
        {
            //Arrange
            var contactToSave = new Contact
            {
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };

            _mockContactRepository.Setup(x => x.Post(It.IsAny<Contact>())).Returns(0);

            //Act
            var result = _sut.Post(contactToSave);

            Assert.AreEqual(0, result);

            //Assert
            _mockContactRepository.Verify(x => x.Post(It.IsAny<Contact>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ContactServiceException))]
        public void Post_When_Called_Throws_ContactServiceException()
        {
            //Arrange 
            var contactToSave = new Contact
            {
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };
            _mockContactRepository.Setup(x => x.Post(It.IsAny<Contact>())).Throws<ContactServiceException>();

            //Act
            _sut.Post(contactToSave);
        }

        [TestMethod]
        public void Put_When_Called_Then_Call_RepositoryPut_AsExpected()
        {
            //Arrange
            var contactToUpdate = new Contact
            {
                Id = 1,
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };

            _mockContactRepository.Setup(x => x.Put(It.IsAny<Contact>())).Returns(0);

            //Act
            var result = _sut.Put(contactToUpdate);

            Assert.AreEqual(0, result);

            //Assert
            _mockContactRepository.Verify(x => x.Put(It.IsAny<Contact>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ContactServiceException))]
        public void Put_When_Called_Throws_ContactServiceException()
        {
            //Arrange 
            var contactToUpdate = new Contact
            {
                Id = 1,
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };
            _mockContactRepository.Setup(x => x.Put(It.IsAny<Contact>())).Throws<ContactServiceException>();

            //Act
            _sut.Put(contactToUpdate);
        }

        [TestMethod]
        public void Delete_When_Called_Then_Call_RepositoryDelete_AsExpected()
        {
            //Arrange          
            _mockContactRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(0);

            //Act
            var result = _sut.Delete(1);

            Assert.AreEqual(0, result);

            //Assert
            _mockContactRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ContactServiceException))]
        public void Delete_When_Called_Throws_ContactServiceException()
        {
            //Arrange
            _mockContactRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws<ContactServiceException>();

            //Act
            _sut.Delete(1);
        }
    }
}
