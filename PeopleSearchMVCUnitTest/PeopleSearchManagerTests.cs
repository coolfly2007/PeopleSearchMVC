using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeopleSearchMvc.Data;
using PeopleSearchMvc.Manager;
using PeopleSearchMvc.Models;

namespace PeopleSearchMVCUnitTest
{
    [TestClass]
    public class PeopleSearchManagerTests
    {
        private PeopleSearchManager _peopleSearchManager;
        private Mock<IPeopleRespository> _peopleSearchRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            _peopleSearchRepositoryMock = new Mock<IPeopleRespository>();
            _peopleSearchManager = new PeopleSearchManager(_peopleSearchRepositoryMock.Object);
        }

        [TestMethod]
        public void GetPersonSearchResult_CallRepositorySuccessfully()
        {
            const string searchString = "test";
            _peopleSearchRepositoryMock.Setup(p => p.GetPeopleSearchResultModel(It.IsAny<string>()))
                .Returns(It.IsAny<IReadOnlyCollection<PeopleSearchResultModel>>());
            _peopleSearchManager.GetPersonSearchResult(searchString);
            _peopleSearchRepositoryMock.Verify(p => p.GetPeopleSearchResultModel(searchString));
        }

        [TestMethod]
        public void GetPersonSearchResult_ReturnCorrectResults()
        {
            const string searchString = "test";
            var list = new List<PeopleSearchResultModel>
            {
                new PeopleSearchResultModel
                {
                    Id = 1
                },
                new PeopleSearchResultModel
                {
                    Id = 2
                },
                new PeopleSearchResultModel
                {
                    Id = 3
                }
            };
            _peopleSearchRepositoryMock.Setup(p => p.GetPeopleSearchResultModel(searchString))
                .Returns(list);
            var actual = _peopleSearchManager.GetPersonSearchResult(searchString);
            Assert.AreEqual(list, actual);
        }
    }
}