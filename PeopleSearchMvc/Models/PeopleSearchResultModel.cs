using System;
using System.Collections.Generic;

namespace PeopleSearchMvc.Models
{
    public class PeopleSearchResultModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string AvatarUrl { get; set; }
        public int Age => (DateTime.Now.Year - Birthday.Year);
        public IEnumerable<string> Addresses { get; set; }
        public IEnumerable<string> Interests { get; set; }
    }
}