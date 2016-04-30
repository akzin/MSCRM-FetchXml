using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tofi9.FetchXml.Querying;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace Tofi9.FetchXml.Tests
{
    [TestClass]
    public class DemoQueries
    {
        [TestMethod]
        public void DemoAttributes()
        {
            var query = new FetchQuery("lead")
                .Filter(f => f.Gt("budgetamount", 5000))
                .Attributes("fullname", "companyname", "budgetamount");

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?>
<fetch xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <entity name=""lead"">
    <filter>
      <condition attribute=""budgetamount"" operator=""gt"" value=""5000"" />
    </filter>
    <attribute name=""fullname"" />
    <attribute name=""companyname"" />
    <attribute name=""budgetamount"" />
  </entity>
</fetch>", fetchxml);
        }

        /// <summary>
        /// select firstname, lastname, fullname
        /// from contact
        /// where (firstname = Sam and lastname = Jones) or lastname like *(sample)*
        /// </summary>
        [TestMethod]
        public void DemoFilter()
        {
            var query = new FetchQuery("contact")
                .Attributes("firstname", "lastname", "fullname")
                .Filter(f => f
                    .SubFilterOr(f2 => f2
                        .SubFilterAnd(f3 => f3
                            .Eq("firstname", "Sam")
                            .Eq("lastname", "Jones"))
                        .SubFilterAnd(f3 => f3
                            .Like("lastname", "%(sample)%"))))
                .AllAttributes();

            var fetchxml = query.ToString();

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-16""?>
<fetch xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <entity name=""contact"">
    <filter>
      <filter type=""or"">
        <filter>
          <condition attribute=""firstname"" operator=""eq"" value=""Sam"" />
          <condition attribute=""lastname"" operator=""eq"" value=""Jones"" />
        </filter>
        <filter>
          <condition attribute=""lastname"" operator=""like"" value=""%(sample)%"" />
        </filter>
      </filter>
    </filter>
    <attribute name=""firstname"" />
    <attribute name=""lastname"" />
    <attribute name=""fullname"" />
    <all-attributes />
  </entity>
</fetch>", fetchxml);
        }
    }
}
