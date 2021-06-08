using Contacts.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Contacts.Tests
{
    [TestClass]
    public class HackathonRepositoryTests
    {

        [TestInitialize]
        public void HackathonRespositoryInitialize()
        {
            var mockSet = new Mock<DbSet<Contact>>();
            //mockSet.As<IQueryable<Hackathon>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSet.As<IQueryable<Hackathon>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<Hackathon>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<Hackathon>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
