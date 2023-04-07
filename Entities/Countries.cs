using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_02_EntityFramework.Entities
{
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cities> Cities { get; set; }

    }
}
