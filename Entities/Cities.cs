
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_02_EntityFramework.Entities
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flight> Flight { get; set; }
        public Countries Countries { get; set; }
        public int CountriesId { get; set; }

    }
}
