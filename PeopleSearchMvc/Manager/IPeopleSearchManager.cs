using System.Collections.Generic;
using System.Reflection.Emit;
using PeopleSearchMvc.Models;

namespace PeopleSearchMvc.Manager
{
    public interface IPeopleSearchManager
    {
        IReadOnlyCollection<PeopleSearchResultModel> GetPersonSearchResult(string searchString);
    }
}
