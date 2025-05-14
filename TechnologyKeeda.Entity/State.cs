using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.Entity
{
    //State---------------(*) City
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default State";
        public int CountryId { get; set; } //Foregin Key
        //Navigation property
        public Country? Country { get; set; }
        //Navigation property
        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
