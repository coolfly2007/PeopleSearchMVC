using System.Collections.Generic;
using System.Linq;
using PeopleSearchMvc.Models;

namespace PeopleSearchMvc.Data
{
    public class PeopleRespository : IPeopleRespository
    {
        public IReadOnlyCollection<PeopleSearchResultModel> GetPeopleSearchResultModel(string searchString)
        {
            using (var context = new PeopleSearchCodeFirstModel())
            {
                searchString = searchString?.Trim();
                return (from person in context.People
                    where searchString == null || searchString.Trim() == string.Empty ||
                          person.FirstName.Contains(searchString) || person.LastName.Contains(searchString)
                    join address in context.Addresses
                        on person.Id equals address.Id into a
                    join interest in context.Interests
                        on person.Id equals interest.Id into i
                    select new PeopleSearchResultModel
                    {
                        Id = person.Id,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Birthday = person.Birthday,
                        AvatarUrl = person.AvatarUrl,
                        Addresses = a.Select(add => add.Address1),
                        Interests = i.Select(interest => interest.Interest1)
                    }).ToList();
            }
        }
    }
}