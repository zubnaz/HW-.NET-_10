using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_02_EntityFramework.Entities
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
