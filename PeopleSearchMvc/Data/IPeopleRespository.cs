using System.Collections.Generic;
using PeopleSearchMvc.Models;

namespace PeopleSearchMvc.Data
{
    public interface IPeopleRespository
    {
        IReadOnlyCollection<PeopleSearchResultModel> GetPeopleSearchResultModel(string searchString);
    }
}