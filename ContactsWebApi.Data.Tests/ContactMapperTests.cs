using ContactsWebApi.Data.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactsWebApi.Data.Tests
{
    [TestClass]
    public class ContactMapperTests :ContactTestBase
    {
        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
        }

        [TestMethod]
        public void MapToContactList_WhenMapping_ThenFieldsAreMappedAsExpected()
        {
            var mappedContactResult = ContactMapper.MapToContactList(contactsList);

            Assert.IsNotNull(mappedContactResult, "Contact Result is not null");

            Assert.AreEqual(contactsList[0].Id, mappedContactResult[0].Id, "Id");
            Assert.AreEqual(contactsList[0].FirstName, mappedContactResult[0].FirstName, "FirstName");
            Assert.AreEqual(contactsList[0].LastName, mappedContactResult[0].LastName, "LastName");
            Assert.AreEqual(contactsList[0].Email, mappedContactResult[0].Email, "Email");
            Assert.AreEqual(contactsList[0].Phone, mappedContactResult[0].Phone, "Phone");
            Assert.AreEqual(contactsList[0].Status, mappedContactResult[0].Status, "Status");

            Assert.AreEqual(contactsList[1].Id, mappedContactResult[1].Id, "Id");
            Assert.AreEqual(contactsList[1].FirstName, mappedContactResult[1].FirstName, "FirstName");
            Assert.AreEqual(contactsList[1].LastName, mappedContactResult[1].LastName, "LastName");
            Assert.AreEqual(contactsList[1].Email, mappedContactResult[1].Email, "Email");
            Assert.AreEqual(contactsList[1].Phone, mappedContactResult[1].Phone, "Phone");
            Assert.AreEqual(contactsList[1].Status, mappedContactResult[1].Status, "Status");

            Assert.AreEqual(contactsList[2].Id, mappedContactResult[2].Id, "Id");
            Assert.AreEqual(contactsList[2].FirstName, mappedContactResult[2].FirstName, "FirstName");
            Assert.AreEqual(contactsList[2].LastName, mappedContactResult[2].LastName, "LastName");
            Assert.AreEqual(contactsList[2].Email, mappedContactResult[2].Email, "Email");
            Assert.AreEqual(contactsList[2].Phone, mappedContactResult[2].Phone, "Phone");
            Assert.AreEqual(contactsList[2].Status, mappedContactResult[2].Status, "Status");
        }
    }
}
