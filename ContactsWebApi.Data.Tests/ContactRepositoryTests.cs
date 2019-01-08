using ContactsWebApi.Data.Interface;
using ContactsWebApi.Data.Model;
using ContactsWebApi.Data.Repository;
using ContactsWebApi.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ContactsWebApi.Data.Tests
{
    [TestClass]
    public class ContactRepositoryTests : ContactTestBase
    {
        private ContactRepository _sut;
        private Mock<IDatabase> _mockDatabase;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();

            _mockDatabase = new Mock<IDatabase>();
            _sut = new ContactRepository(_mockDatabase.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContactRepository_WhenConstructed_WithANull_ThenThrows_AnArgumentNullException()
        {
            var contactRepository = new ContactRepository(null);
        }

        [TestMethod]
        public void List_When_Called_Then_Call_List_AsExpected()
        {
            //Arrange  
            var contactList = new List<ContactResult>
            {
                new ContactResult
                    {
                        Id=1,
                        FirstName = "Ajay",
                        LastName = "Patil",
                        Email = "ajay.patil@gmail.com",
                        Phone = "9000000000",
                        Status = true
                    },
                    new ContactResult
                    {
                        Id=2,
                        FirstName = "Amit",
                        LastName = "Patil",
                        Email = "amit.patil@gmail.com",
                        Phone = "9100000000",
                        Status = true
                    }
            };

            _mockDatabase.Setup(x => x.List<ContactResult>(It.IsAny<string>())).Returns(contactList);

            //Act
            var result = (List<Contact>)_sut.List();

            Assert.AreEqual(contactList.Count, result.Count);

            //Assert
            _mockDatabase.Verify(x => x.List<ContactResult>(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Post_When_Called_Then_Call_Save_AsExpected()
        {
            //Arrange
            var newContact = new Domain.Model.Contact
            {
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };

            _mockDatabase.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Verifiable();

            //Act
            _sut.Post(newContact);

            //Assert
            _mockDatabase.Verify(x => x.Save(It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Once);
        }

        [TestMethod]
        public void Put_When_Called_Then_Call_Update_AsExpected()
        {
            //Arrange
            var contactToUpdate = new Domain.Model.Contact
            {
                Id = 1,
                FirstName = "Ajay",
                LastName = "Patil",
                Email = "ajay.patil@gmail.com",
                Phone = "9000000000",
                Status = true
            };

            _mockDatabase.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Verifiable();

            //Act
            _sut.Put(contactToUpdate);

            //Assert
            _mockDatabase.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Once);
        }

        [TestMethod]
        public void Delete_When_Called_Then_Call_Delete_AsExpected()
        {
            //Arrange          
            _mockDatabase.Setup(x => x.Delete(It.IsAny<string>(), It.IsAny<SqlParameter[]>())).Verifiable();

            //Act
            _sut.Delete(1);

            //Assert
            _mockDatabase.Verify(x => x.Delete(It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Once);
        }
    }
}
