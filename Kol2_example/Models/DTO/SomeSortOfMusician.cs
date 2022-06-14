using System.Collections.Generic;

namespace Kol2_example.Models.DTO
{
    public class SomeSortOfMusician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
