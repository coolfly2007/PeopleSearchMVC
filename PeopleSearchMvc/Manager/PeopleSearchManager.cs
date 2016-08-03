using System.Collections.Generic;
using PeopleSearchMvc.Data;
using PeopleSearchMvc.Models;

namespace PeopleSearchMvc.Manager
{
    public class PeopleSearchManager : IPeopleSearchManager
    {
        private readonly IPeopleRespository _peopleRespository;

        public PeopleSearchManager(IPeopleRespository peopleRespository)
        {
            _peopleRespository = peopleRespository;
        } 
        public IReadOnlyCollection<PeopleSearchResultModel> GetPersonSearchResult(string searchString)
        {
            return _peopleRespository.GetPeopleSearchResultModel(searchString);
        }
    }
}